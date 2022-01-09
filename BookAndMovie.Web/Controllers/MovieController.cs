using AutoMapper;
using BookAndMovie.Domain;
using BookAndMovie.Services.Interfaces;
using BookAndMovie.Web.ViewModels.Movie;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndMovie.Web.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService movieService;
        private readonly IMapper mapper;

        public MovieController(IMovieService movieService, IMapper mapper)
        {
            this.movieService = movieService;
            this.mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetMovieById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get(string id)
        {
            var movie = await this.movieService.FindByIdAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            var movieViewModel = this.mapper.Map<MovieViewModel>(movie);

            return Ok(movieViewModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateMovie (CreateMovieViewModel movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newMovie = this.mapper.Map<Movie>(movie);
            await this.movieService.CreateMovieAsync(newMovie);
            var movieViewModel = this.mapper.Map<CreateMovieViewModel>(newMovie);

            return CreatedAtRoute("GetMovieById", new { id = movieViewModel.Id }, movieViewModel); ;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllMovies()
        {
            var allMovies = await this.movieService.GetAllMoviesAsync();

            if (allMovies.Count == 0)
            {
                return NotFound();
            }

            var moviesViewModels = this.mapper.Map<IList<MovieViewModel>>(allMovies);

            return Ok(moviesViewModels);
        }

        [HttpGet]
        [Route("allUserMovies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllMoviesByUserIdAsync(string id)
        {
            var userMovies = await this.movieService.GetAllMovieByUserIdAsync(id);

            if (userMovies == null)
            {
                return NotFound();
            }

            var moviesViewModels = this.mapper.Map<MovieViewModel>(userMovies);

            return Ok(moviesViewModels);
        }

        [HttpGet]
        [Route("watchedUserMovies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllWatchedMoviesByUserIdsAsync(string id)
        {
            var watchedMovies = await this.movieService.GetAllWatchedMovieByUserIdsAsync(id);

            if (watchedMovies == null)
            {
                return NotFound();
            }

            var moviesViewModels = this.mapper.Map<MovieViewModel>(watchedMovies);

            return Ok(moviesViewModels);
        }

        [HttpGet]
        [Route("unwatchedUserMovies")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllUnunwatchedMoviesByUserIdsAsync(string id)
        {
            var unwatchedMovies = await this.movieService.GetAllUnwatchedMovieByUserIdsAsync(id);

            if (unwatchedMovies == null)
            {
                return NotFound();
            }

            var moviesViewModel = this.mapper.Map<MovieViewModel>(unwatchedMovies);

            return Ok(moviesViewModel);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateMovieStatysByUserId(string userId, Movie movie)
        {
            var updatedMovie = await this.movieService.UpdateMovieStatysByUserId(userId, movie);

            if (updatedMovie == null)
            {
                return NotFound();
            }

            var updatedMovieViewModels = this.mapper.Map<MovieViewModel>(updatedMovie);

            return Ok(updatedMovieViewModels);
        }
    }
}
