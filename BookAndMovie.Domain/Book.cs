using System.ComponentModel.DataAnnotations;

namespace BookAndMovie.Domain
{
    public class Book
    {
        public string Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(100)]
        public string BookImageId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Author { get; set; }
        public bool Readed { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int Review { get; set; }
    }
}
