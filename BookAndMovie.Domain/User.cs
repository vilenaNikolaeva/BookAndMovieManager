using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BookAndMovie.Domain
{
    public class User : IdentityUser
    {
        public ICollection<Book> Books { get; set; }
        public ICollection<Movie> Movies{ get; set; }

    }
}
