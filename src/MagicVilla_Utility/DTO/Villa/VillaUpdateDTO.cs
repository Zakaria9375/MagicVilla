using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Utility.DTO.Villa
{
    public class VillaUpdateDTO : IVillaBaseDTO
    {
        [Required]
        [Length(3, 30)]
        public string Name { get; set; }
        public string? Details { get; set; }
        [Required]
        public double Rate { get; set; }
        public int Sqft { get; set; }
        public int Occupancy { get; set; }
        public string? ImageUrl { get; set; }
        public string? Amenity { get; set; } 
    }
}
