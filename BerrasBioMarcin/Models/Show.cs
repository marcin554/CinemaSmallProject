namespace BerrasBioMarcin.Models
{
    public class Show
    {
        public int ShowID { get; set; }
        public Movie Movie { get; set; }

        public DateTime ShowDate { get; set; }

        public bool IsShowCanceled { get; set; }
    }
}
