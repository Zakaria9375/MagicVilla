

namespace MagicVilla_Utility.DTO.Villa
{
    public interface IVillaBaseDTO
    {
        string Name { get; set; }
        string Details { get; set; }
        double Rate { get; set; }
        int Sqft { get; set; }
        int Occupancy { get; set; }
        string ImageUrl { get; set; }
        string Amenity { get; set; }
    }
}
