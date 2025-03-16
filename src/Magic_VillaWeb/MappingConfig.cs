using AutoMapper;
using MagicVilla_Utility.DTO.Villa;
using MagicVilla_Utility.DTO.VillaNumber;

namespace MagicVilla_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            #region Villa DTOs
            CreateMap<VillaDTO, VillaCreateDTO>().ReverseMap();
            CreateMap<VillaDTO, VillaUpdateDTO>().ReverseMap();
            #endregion

            #region VillaNumber DTOs
            CreateMap<VillaNumberDTO, VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumberDTO, VillaNumberUpdateDTO>().ReverseMap();
            #endregion
        }
    }
}
