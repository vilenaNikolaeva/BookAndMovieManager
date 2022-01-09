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


        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetUserById (string id)
        {
            var user = await this._userService.GetUserByIdAsync(id);
            return Ok(user);
        }
    }
}
