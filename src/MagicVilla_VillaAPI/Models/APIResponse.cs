using System.Net;

namespace MagicVilla_VillaAPI.Models
{

    public class APIResponse<T>(HttpStatusCode statusCode, bool isSuccess, T? result = default, List<string>? messages = null)
    {
        public HttpStatusCode StatusCode { get; init; } = statusCode;
        public List<string> Messages { get; init; } = messages ?? ["Operation was successful"];
        public bool IsSuccess { get; init; } = isSuccess;
        public T? Result { get; init; } = result;
    }

}
