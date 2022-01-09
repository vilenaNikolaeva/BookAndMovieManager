using System.ComponentModel.DataAnnotations;

namespace BookAndMovie.Web.ViewModels.Movie
{
    public class CreateMovieViewModel
    {
        public string Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string MovieUrl { get; set; }
        public string FilmGenre { get; set; }
        public bool Watched { get; set; }
        public int Review { get; set; }
    }
}
