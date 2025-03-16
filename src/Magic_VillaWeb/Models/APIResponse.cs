using System.Net;

namespace MagicVilla_Web.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public List<string> Messages { get; set; }
        public bool IsSuccess { get; set; }
        public object Result { get; set; }
    }
}
