using System.ComponentModel.DataAnnotations;

namespace BookAndMovie.Web.ViewModels.Movie
{
    public class MovieViewModel
    {
        public string Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public string MovieImageUrl { get; set; }
        [Required]
        public string MovieUrl { get; set; }
        public string FilmGenre { get; set; }
        public bool Watched { get; set; }
        public double Rating { get; set; }
    }
}
