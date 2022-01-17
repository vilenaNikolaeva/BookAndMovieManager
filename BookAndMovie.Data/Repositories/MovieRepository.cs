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

        public async Task<IList<Movie>> GetAllMoviesAsync()
        {
            var movies = await this.context.Movies.ToListAsync();
            return movies;
        }

        public async Task<Movie> UpdateMovieIsWatched( string userId , string movieId , bool isWatched)
        {
            var user = await this.context.Users.Include(u => u.Movies).SingleOrDefaultAsync(u => u.Id == userId);

            var movieForUpdate = user.Movies.Where(i => i.Id == movieId).SingleOrDefault();
            movieForUpdate.Watched = isWatched;
            await this.context.SaveChangesAsync();
            return movieForUpdate;
        }
    }
}
