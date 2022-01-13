using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndMovie.Web.ViewModels.Book
{
    public class CreateBookViewModel
    {
        public string Title { get; set; }
        [Required]
        public string BookImageUrl { get; set; }
        public string BookFileUrl { get; set; }

        public string Author { get; set; }
        public bool Readed { get; set; }
        public double Rating { get; set; }

    }
}
