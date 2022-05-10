using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BerrasBioMarcin.Models
{
    public class Salon
    {
       
        public int SalonId { get; set; }
        public string SalonName { get; set; }
        public int AvailableSpace { get; set; }      
        public int CinemaId { get; set; }


        public virtual Cinema? Cinema { get; set; }

        public virtual ICollection<Show?> Shows { get; set; } = new List<Show?>();

       

    }
}
