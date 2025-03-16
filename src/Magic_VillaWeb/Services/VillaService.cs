using MagicVilla_Utility.DTO.Villa;
using MagicVilla_Web.Models;
using MagicVilla_Web.Services.IServices;
using MagicVilla_Utility;

namespace MagicVilla_Web.Services
{
    public class VillaService(IHttpClientFactory clientFactory, IConfiguration configuration) : BaseService(clientFactory), IVillaService
    {
        // private readonly IHttpClientFactory _clientFactory = clientFactory;
        private readonly string _villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");

        public Task<T> CreateAsync<T>(VillaCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = Common.APIType.POST,
                Data = dto,
                Url = _villaUrl + "/villas"
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = Common.APIType.DELETE,
                Url = _villaUrl + "/villas/" + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = Common.APIType.GET,
                Url = _villaUrl + "/villas"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = Common.APIType.GET,
                Url = _villaUrl + "/villas/" + id
            });
        }

        public Task<T> UpdateAsync<T>(int id, VillaUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = Common.APIType.PUT,
                Data = dto,
                Url = _villaUrl + "/villas/" + id
            });
        }
    }
}
