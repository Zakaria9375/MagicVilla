using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Services.IServices;
using Newtonsoft.Json;
using System.Text;
namespace MagicVilla_Web.Services
{
    public class BaseService(IHttpClientFactory httpClient) : IBaseService
    {
        public APIResponse ReponseModel { get; set; } = new();
        public IHttpClientFactory HttpClientFactory { get; set; } = httpClient;

        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var client = HttpClientFactory.CreateClient("MagicAPI");

                var message = new HttpRequestMessage
                {
                    Method = apiRequest.ApiType switch
                    {
                        Common.APIType.POST => HttpMethod.Post,
                        Common.APIType.PUT => HttpMethod.Put,
                        Common.APIType.PATCH => HttpMethod.Patch,
                        Common.APIType.GET => HttpMethod.Get,
                        Common.APIType.DELETE => HttpMethod.Delete,
                        _ => HttpMethod.Get
                    },
                    RequestUri = new Uri(apiRequest.Url),
                    Headers = { { "Accept", "application/json" } }
                };
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
                }

                var apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(apiContent) ?? throw new JsonSerializationException("Failed to deserialize API response");
            }
            catch (Exception ex)
            {
                return HandleException<T>(ex);
            }

        }

        private T HandleErrorResponse<T>(HttpResponseMessage response)
        {
            var errorContent = response.Content.ReadAsStringAsync().Result;
            var dto = new APIResponse
            {
                Messages = new List<string> { $"HTTP {(int)response.StatusCode}: {response.ReasonPhrase}", errorContent },
                IsSuccess = false,
                Result = null
            };
            var res = JsonConvert.SerializeObject(dto);
            return JsonConvert.DeserializeObject<T>(res)!;
        }

        private static T HandleException<T>(Exception ex)
        {
            var dto = new APIResponse
            {
                Messages = [ex.Message],
                IsSuccess = false,
                Result = null
            };
            var res = JsonConvert.SerializeObject(dto);
            return JsonConvert.DeserializeObject<T>(res)!;
        }
    }
}
