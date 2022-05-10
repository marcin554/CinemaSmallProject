using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BerrasBioMarcin.Models
{
    public class Booking
    {

        public int BookingID { get; set; }

        [Range(1, 12)]
        public int AmountSeats { get; set; }
        
        public int ShowsID { get; set; }
        public virtual Show? Shows { get; set; }

        public bool BookingCanceled { get; set; } = false;
    }
}
