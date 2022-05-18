using System.ComponentModel.DataAnnotations.Schema;

namespace BerrasBioMarcin.Models
{
    public class Spot
    {
        public int SpotID { get; set; }
        public bool SpotIsTaken { get; set; } = false;

        [ForeignKey("Salon")]
        public int SalonId { get; set; }
        public virtual Salon? Salon { get; set; }

        [ForeignKey("Show")]

        public int? ShowId { get; set; }

        public virtual Show? Shows { get; set; }

        public int? BookingId { get; set; }


    }
}
