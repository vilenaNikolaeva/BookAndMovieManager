using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndMovie.Web.ViewModels.BookRating
{
    public class CreateBookRatingViewModel
    {
        public string BookId { get; set; }
        public string UserId { get; set; }
        public double Rating { get; set; }
    }
}
