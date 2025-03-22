using MagicVilla_Utility.DTO.Villa;
using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Utility.DTO.VillaNumber
{
    public class VillaNumberUpdateDTO : IVillaNubmerDTO
    {
        [Required]
        public int VillaID { get; set; }
        public string SpecialDetails { get; set; }
        public VillaDTO? Villa { get; set; }

    }
}
