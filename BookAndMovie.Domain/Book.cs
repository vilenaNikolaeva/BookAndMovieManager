using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookAndMovie.Domain
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string BookImageUrl { get; set; }
        public string BookFileUrl { get; set; }
        public string Author { get; set; }
        public bool Readed { get; set; }
        public double Rating { get; set; }
        public int RatingCount { get; set; }
        public ICollection<User> Users{ get; set; }


    }
}
