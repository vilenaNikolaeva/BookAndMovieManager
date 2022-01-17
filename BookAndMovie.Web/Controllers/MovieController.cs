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
        public async Task<ActionResult> CreateMovieAsync (CreateMovieViewModel movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newMovie = this.mapper.Map<Movie>(movie);
            await this.movieService.CreateMovieAsync(newMovie);
            var movieViewModel = this.mapper.Map<MovieViewModel>(newMovie);

            return CreatedAtRoute("GetMovieById", new { id = movieViewModel.Id }, movieViewModel); ;
        }

        [HttpPut]
        [Route("watched")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateMovieIsWatched(string userId,string movieId, bool isWatched)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

             var movie= await this.movieService.UpdateMovieIsWatched(userId,movieId,isWatched);
             var movieViewModel = this.mapper.Map<CreateMovieViewModel>(movie);

            return Ok(movieViewModel);
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

    }
}
