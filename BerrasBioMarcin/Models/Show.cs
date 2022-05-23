using System.ComponentModel.DataAnnotations;

namespace BerrasBioMarcin.Models
{
    public class Show
    {
       
        public int ShowID { get; set; }
        
        
        public DateTime ShowDate { get; set; }
        
        public bool IsShowCanceled { get; set; } = false;


        public int MovieId { get; set; }

        public int? SalonId { get; set; }



        public virtual Salon? Salon { get; set; }
        public virtual Movie? Movie { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public virtual ICollection<Spot> Spots { get; set; } = new List<Spot>();

    }
}
