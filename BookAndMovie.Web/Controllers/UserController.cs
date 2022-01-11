using AutoMapper;
using BookAndMovie.Domain;
using BookAndMovie.Services.Interfaces;
using BookAndMovie.Web.ViewModels.Book;
using BookAndMovie.Web.ViewModels.Movie;
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
        private readonly IUserService userService;
        private readonly IWebHostEnvironment hostEnvironment;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IWebHostEnvironment hostEnvironment, IMapper mapper)
        {
            this.userService = userService;
            this.hostEnvironment = hostEnvironment;
            this.mapper = mapper;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AddBookToUserLibraryByIdAsync(string userId, string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this.userService.AddBookToLibraryById(userId, id);
            return Ok();
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeleteBookFromUserListAsync (string userId, string id)
        {
            await this.userService.DeleteBookFromUserListAsync(userId, id);
            return Ok();
        }
        
        
        [HttpGet]
        [Route("Books")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllBooksByUserIdAsync(string id)
        {
            var userBooks = await this.userService.GetAllBooksByUserIdAsync(id);

            if (userBooks == null)
            {
                return NotFound();
            }

            //var booksViewModels = this.mapper.Map<BookViewModel>(userBooks);

            return Ok(userBooks);
        }

        [HttpGet]
        [Route("ReadedBooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllReadedBookByUserIdsAsync(string id)
        {
            var readedBooks = await this.userService.GetAllReadedBookByUserIdsAsync(id);

            if (readedBooks == null)
            {
                return NotFound();
            }

            var booksViewModels = this.mapper.Map<CreateBookViewModel>(readedBooks);

            return Ok(booksViewModels);
        }

        [HttpGet]
        [Route("UnreadedBooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllUnreadedBookByUserIdsAsync(string id)
        {
            var unreadedBooks = await this.userService.GetAllUnreadedBookByUserIdsAsync(id);

            if (unreadedBooks == null)
            {
                return NotFound();
            }

            var booksViewModels = this.mapper.Map<CreateBookViewModel>(unreadedBooks);

            return Ok(booksViewModels);
        }

        [HttpPut("{bookId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateBookStatysByUserId(string userId, Book book)
        {
            var updatedBook = await this.userService.UpdateBookStatysByUserId(userId,book);

            if (updatedBook == null)
            {
                return NotFound();
            }

            var booksViewModels = this.mapper.Map<CreateBookViewModel>(updatedBook);

            return Ok(booksViewModels);
        }

        ////  <=== MOVIES

        [HttpGet]
        [Route("allMovies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllMoviesByUserIdAsync(string id)
        {
            var userMovies = await this.userService.GetAllMovieByUserIdAsync(id);

            if (userMovies == null)
            {
                return NotFound();
            }

            var moviesViewModels = this.mapper.Map<MovieViewModel>(userMovies);

            return Ok(moviesViewModels);
        }

        [HttpGet]
        [Route("watchedMovies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllWatchedMoviesByUserIdsAsync(string id)
        {
            var watchedMovies = await this.userService.GetAllWatchedMovieByUserIdsAsync(id);

            if (watchedMovies == null)
            {
                return NotFound();
            }

            var moviesViewModels = this.mapper.Map<MovieViewModel>(watchedMovies);

            return Ok(moviesViewModels);
        }

        [HttpGet]
        [Route("unwatchedMovies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllUnunwatchedMoviesByUserIdsAsync(string id)
        {
            var unwatchedMovies = await this.userService.GetAllUnwatchedMovieByUserIdsAsync(id);

            if (unwatchedMovies == null)
            {
                return NotFound();
            }

            var moviesViewModel = this.mapper.Map<MovieViewModel>(unwatchedMovies);

            return Ok(moviesViewModel);
        }

        [HttpPut("{movieId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateMovieStatysByUserId(string userId, Movie movie)
        {
            var updatedMovie = await this.userService.UpdateMovieStatysByUserId(userId, movie);

            if (updatedMovie == null)
            {
                return NotFound();
            }

            var updatedMovieViewModels = this.mapper.Map<MovieViewModel>(updatedMovie);

            return Ok(updatedMovieViewModels);
        }
    }
}
