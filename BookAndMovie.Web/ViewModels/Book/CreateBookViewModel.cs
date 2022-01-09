using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndMovie.Web.ViewModels.Book
{
    public class CreateBookViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string BookImageId { get; set; }
        public string Author { get; set; }
        public bool Readed { get; set; }
        public int Review { get; set; }

    }
}
