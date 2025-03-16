using AutoMapper;
using MagicVilla_Utility.DTO.Villa;
using MagicVilla_Utility.DTO.VillaNumber;
using MagicVilla_VillaAPI.Models;

namespace MagicVilla_VillaAPI
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            #region Villa DTOs
            CreateMap<Villa, VillaDTO>().ReverseMap();
            CreateMap<VillaDTO, VillaCreateDTO>().ReverseMap();
            CreateMap<Villa, VillaCreateDTO>().ReverseMap();
            CreateMap<Villa, VillaUpdateDTO>().ReverseMap();
            #endregion

            #region VillaNumber DTOs
            CreateMap<VillaNumber, VillaNumberDTO>().ReverseMap();
            CreateMap<VillaNumberDTO, VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumber, VillaNumberUpdateDTO>().ReverseMap();
            #endregion
        }
    }
}
