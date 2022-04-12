using System.ComponentModel.DataAnnotations.Schema;

namespace BerrasBioMarcin.Models
{
    public class Spot
    {
        public int SpotID { get; set; }
        public bool SpotIsTaken { get; set; }

        [ForeignKey("Salon")]
        public int SalonId { get; set; }
        public Salon Salon { get; set; }
    }
}
