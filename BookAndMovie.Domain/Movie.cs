using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndMovie.Domain
{
    public class Movie
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string MovieUrl { get; set; }
        public string MovieImageUrl { get; set; }
        public string  FilmGenre { get; set; }
        public bool Watched { get; set; }
        public int Review { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
