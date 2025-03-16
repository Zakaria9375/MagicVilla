using static MagicVilla_Utility.Common;

namespace MagicVilla_Web.Models
{
    public class APIRequest
    {
        public APIType ApiType { get; set; } = APIType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
