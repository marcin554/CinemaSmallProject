using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BerrasBioMarcin.ViewModels
{
    public class MovieViewModel
    {
        [Required(ErrorMessage = "Please choose a Movie Image")]
        [Display(Name = "Movie Picture")]
        public IFormFile MovieImage { get; set; }

        [Required(ErrorMessage = "Please write the movie Title")]
        [Display(Name = "Movie")]
        public string MovieTitleName { get; set; }

        public string MovieDescription { get; set; }
        public DateTime MovieReleaseDate { get; set; }
        

        public int GenreId { get; set; }      
        public double Price { get; set; }

    }
}
