using MagicVilla_Utility.DTO.VillaNumber;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MagicVilla_Web.Models
{
    public class VillaNumberVM<T> : IVillaNumberVM<T> where T : class, IVillaNubmerDTO, new()
    {
        public T VillaNumber { get; set; } = new T();

        [ValidateNever]
        public IEnumerable<SelectListItem> VillaList { get; set; } = [];
    }

}
