using System.ComponentModel.DataAnnotations;

namespace BerrasBioMarcin.Models
{
    public class Show
    {
        [Required(ErrorMessage="1")]
        public int ShowID { get; set; }
        
        [Required(ErrorMessage = "3")]
        public DateTime ShowDate { get; set; }
        [Required(ErrorMessage = "4")]
        public bool IsShowCanceled { get; set; } = false;


        [Required(ErrorMessage = "2")]
        public int MovieId { get; set; }

        public int? SalonId { get; set; }



        public virtual Salon? Salon { get; set; }
        public virtual Movie? Movie { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public virtual ICollection<Spot> Spots { get; set; } = new List<Spot>();

    }
}
