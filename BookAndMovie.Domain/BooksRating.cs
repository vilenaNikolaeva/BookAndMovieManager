using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndMovie.Domain
{
    public class BooksRating
    {
        public string Id { get; set; }
        public string  BookId { get; set; }
        public string  UserId { get; set; }
        public double Rating { get; set; }
    }
}
