namespace BerrasBioMarcin.Models
{
    public class Salons
    {

        public int SalonId { get; set; }

        public string SalonName { get; set; }

        public int AvailableSpace { get; set; }

        public Cinema Cinema { get; set; }

        public Shows? Shows { get; set; }

    }
}
