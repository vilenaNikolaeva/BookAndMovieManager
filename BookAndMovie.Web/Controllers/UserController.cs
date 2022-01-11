using BookAndMovie.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookAndMovie.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _hostEnvironment;

        public UserController(IUserService userService , IWebHostEnvironment hostEnvironment )
        {
            this._userService = userService;
            this._hostEnvironment = hostEnvironment;
        }


        [HttpPost("{id}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddBookToUserLibraryByIdAsync(string userId, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this._userService.AddBookToLibraryById(userId, id);
            return Ok();
        }
    }
}
