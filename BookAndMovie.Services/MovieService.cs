using BookAndMovie.Data.Repositories.Interfaces;
using BookAndMovie.Domain;
using BookAndMovie.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAndMovie.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }

        public async Task<Movie> CreateMovieAsync(Movie movie)
        {
            return await this.movieRepository.CreateMovieAsync(movie);
        }

        public async  Task<Movie> FindByIdAsync(string id)
        {
            return await this.movieRepository.FindByIdAsync(id);
        }

        public async Task<IList<Movie>> GetAllMoviesAsync()
        {
            return await this.movieRepository.GetAllMoviesAsync();
        }
    }
}
