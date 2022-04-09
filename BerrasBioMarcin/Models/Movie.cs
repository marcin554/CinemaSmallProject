using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace BerrasBioMarcin.Models
{
    public class Movie
    {   
        public int MovieId { get; set; }

        
        public string MovieTitleName { get; set; }

       
        
        public DateTime MovieReleaseDate { get; set; }

        
        [ForeignKey("GenresId")]
        public int GenresId { get; set; }

        public double Price { get; set; }

        
    }
}
