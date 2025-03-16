using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla_Utility.DTO.VillaNumber
{
    public interface IVillaNumberVM<T> where T : IVillaNubmerDTO
    {
        T VillaNumber { get; set; }
        IEnumerable<SelectListItem> VillaList { get; set; }
    }
}
