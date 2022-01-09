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

        public async Task<IList<Movie>> GetAllMovieByUserIdAsync(string id)
        {
            return await this.movieRepository.GetAllMovieByUserIdAsync(id);
        }

        public async  Task<IList<Movie>> GetAllMoviesAsync()
        {
            return await this.movieRepository.GetAllMoviesAsync();
        }

        public async Task<IList<Movie>> GetAllUnwatchedMovieByUserIdsAsync(string id)
        {
            return await this.movieRepository.GetAllUnwatchedMovieByUserIdsAsync(id);
        }

        public async  Task<IList<Movie>> GetAllWatchedMovieByUserIdsAsync(string id)
        {
            return await this.movieRepository.GetAllWatchedMovieByUserIdsAsync(id);
        }

        public async Task<Movie> UpdateMovieStatysByUserId(string userId, Movie movie)
        {
            return await this.movieRepository.UpdateMovieStatysByUserId(userId, movie);
        }
    }
}
