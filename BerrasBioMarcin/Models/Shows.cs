namespace BerrasBioMarcin.Models
{
    public class Shows
    {
        public int ShowsID { get; set; }
        public Movie Movie { get; set; }

        public DateTime ShowDate { get; set; }

        public bool IsShowsCanceled { get; set; }
    }
}
