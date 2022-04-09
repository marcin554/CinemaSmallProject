namespace BerrasBioMarcin.Models
{
    public class Booking
    {

        public int BookingID { get; set; }

        public Customer Customer { get; set; }

        public Shows Shows { get; set; }

        public Salons Salons { get; set; }

        public Spot Spot { get; set; }

        public bool BookingCanceled { get; set; }
    }
}
