using System.ComponentModel.DataAnnotations;

namespace BookAndMovie.Web.ViewModels.User
{
    public class LoginUserViewModel
    {
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
