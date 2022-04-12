using System.ComponentModel.DataAnnotations.Schema;

namespace BerrasBioMarcin.Models
{
    public class Salon
    {

        public int SalonId { get; set; }

        public string SalonName { get; set; }

        public int AvailableSpace { get; set; }

        [ForeignKey("Cinema")]
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }

        public ICollection<Show?> Shows { get; set; }

    }
}
