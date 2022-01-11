using System.Collections.Generic;
using BookAndMovie.Domain;

namespace BookAndMovie.Web.ViewModels.Book
{
    public class BookViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string BookImageUrl { get; set; }
        public string BookFileUrl { get; set; }
        public string Author { get; set; }
        public bool Readed { get; set; }
        public int Review { get; set; }
    }
}
