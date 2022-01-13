using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndMovie.Domain
{
    public class MoviesRating
    {
        public string Id { get; set; }
        public string MovieId { get; set; }
        public string UserId { get; set; }
        public double Rating { get; set; }
    }
}
