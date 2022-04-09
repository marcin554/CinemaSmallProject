namespace BerrasBioMarcin.Models
{
    public class Spot
    {
        public int SpotID { get; set; }
        public bool SpotIsTaken { get; set; }

        public Salons Salons { get; set; }
    }
}
