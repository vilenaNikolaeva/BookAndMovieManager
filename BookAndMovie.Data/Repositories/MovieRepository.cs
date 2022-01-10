using BookAndMovie.Data.Repositories.Interfaces;
using BookAndMovie.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndMovie.Data.Repositories
{
    public class MovieRepository : BaseRepositoryContext, IMovieRepository
    {
        public MovieRepository(BookAndMovieDbContext context) : base(context)
        {
        }

        public async Task<Movie> CreateMovieAsync(Movie movie)
        {
            var guid = Guid.NewGuid();
            movie.Id = guid.ToString();
            await this.context.Movies.AddAsync(movie);
            await this.context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> FindByIdAsync(string id)
        {
            return await this.context.Movies.FindAsync(id);
        }

        public async Task<IList<Movie>> GetAllMovieByUserIdAsync(string id)
        {
            var userMovies = await this.context.Movies.Where(b => b.UserId == id).ToListAsync();
            return userMovies;
        }

        public async Task<IList<Movie>> GetAllMoviesAsync()
        {
            var movies = await this.context.Movies.ToListAsync();
            return movies;
        }

        public async Task<IList<Movie>> GetAllUnwatchedMovieByUserIdsAsync(string id)
        {
            var unwatchedMovies = await this.context.Movies.Where(u => u.UserId == id && u.Watched == false).ToListAsync();
            return unwatchedMovies;
        }

        public async Task<IList<Movie>> GetAllWatchedMovieByUserIdsAsync(string id)
        {
            var watchedMovies = await this.context.Movies.Where(u => u.UserId == id && u.Watched == true).ToListAsync();
            return watchedMovies;
        }

        public async Task<Movie> UpdateMovieStatysByUserId(string userId, Movie movie)
        {
            var movieForUpdate = await this.FindByIdAsync(movie.Id);
            movieForUpdate.Watched = movie.Watched;
            this.context.Movies.Update(movieForUpdate);
            await this.context.SaveChangesAsync();
            return movieForUpdate;
        }
    }
}
