using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace BerrasBioMarcin.Models
{
    public class Movie
    {
        [Required]
        public int MovieId { get; set; }

        [Required]
        public string MovieTitleName { get; set; }


        [Required]
        public DateTime MovieReleaseDate { get; set; }

        [Required]
        [ForeignKey("Genre")]
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }


        [Required]
        public string MoviePath { get; set; }


        [Required]
        public double Price { get; set; }

        
    }
}
