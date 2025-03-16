using MagicVilla_Utility.DTO.Villa;
using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Services.IServices;
using MagicVilla_Utility.DTO.VillaNumber;

namespace MagicVilla_Web.Services
{
    public class VillaNumberService(IHttpClientFactory clientFactory, IConfiguration configuration) : BaseService(clientFactory), IVillaNumberService
    {
        private readonly string _villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI") + "/villaNumbers/";
        public Task<T> CreateAsync<T>(VillaNumberCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = Common.APIType.POST,
                Data = dto,
                Url = _villaUrl
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = Common.APIType.DELETE,
                Url = _villaUrl + id
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = Common.APIType.GET,
                Url = _villaUrl
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = Common.APIType.GET,
                Url = _villaUrl + id
            });
        }

        public Task<T> UpdateAsync<T>(int id, VillaNumberUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = Common.APIType.PUT,
                Data = dto,
                Url = _villaUrl + id
            });
        }
    }
}
