using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndMovie.Web.ViewModels.MovieRating
{
    public class CreateMovieRatingViewModel
    {
        public string MovieId { get; set; }
        public string UserId { get; set; }
        public double Rating { get; set; }
    }
}
