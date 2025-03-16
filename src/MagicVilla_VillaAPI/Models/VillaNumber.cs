using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagicVilla_VillaAPI.Models
{
    public class VillaNumber
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ConcurrencyCheck]
        public int Code { get; set; }
        [ForeignKey("Villa")]
        public int VillaID { get; set; }
        public Villa Villa { get; set; }
        public string SpecialDetails { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        [ConcurrencyCheck]
        public DateTime LastUpdatedDate { get; set; } = DateTime.UtcNow;
    }
}
