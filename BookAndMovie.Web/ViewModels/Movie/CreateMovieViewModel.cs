using System.ComponentModel.DataAnnotations;

namespace BookAndMovie.Web.ViewModels.Movie
{
    public class CreateMovieViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string MovieImageUrl { get; set; }
        [Required]
        public string MovieUrl { get; set; }
        public string FilmGenre { get; set; }
        public bool Watched { get; set; }
        //public string Progress { get; set; }
        public int Review { get; set; }
    }
}
