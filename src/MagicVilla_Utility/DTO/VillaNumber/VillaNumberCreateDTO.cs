using MagicVilla_Utility.DTO.Villa;
using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Utility.DTO.VillaNumber
{
    public class VillaNumberCreateDTO : IVillaNubmerDTO
    {
        [Required]
        [Range(100, int.MaxValue, ErrorMessage = "Code must be a three-digit number or greater.")]
        public int Code { get; set; }
        [Required]
        public int VillaID { get; set; }
        public string SpecialDetails { get; set; }
        public VillaDTO? Villa { get; set; }

    }
}
