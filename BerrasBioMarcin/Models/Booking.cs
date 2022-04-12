namespace BerrasBioMarcin.Models
{
    public class Booking
    {

        public int BookingID { get; set; }

        public Customer Customer { get; set; }

        public Show Shows { get; set; }

        public Salon Salons { get; set; }

        public Spot Spot { get; set; }

        public bool BookingCanceled { get; set; }
    }
}
