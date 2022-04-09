namespace BerrasBioMarcin.Models
{
    public class BookingResult
    {

        public int BookingResultID { get; set; }
        public Booking Booking { get; set; }

        public Customer Customer { get; set; }
    }
}
