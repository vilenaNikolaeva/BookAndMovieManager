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
        public string UserId { get; set; }
        public User User { get; set; }
        public int Review { get; set; }
    }
}
