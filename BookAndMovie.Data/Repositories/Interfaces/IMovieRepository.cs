using BookAndMovie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndMovie.Data.Repositories.Interfaces
{
    public interface IMovieRepository
    {
        public Task<Movie> FindByIdAsync(string id);
        public Task<Movie> CreateMovieAsync(Movie movie);
        public Task<IList<Movie>> GetAllMoviesAsync();
        public Task<Movie> UpdateMovieIsWatched(string userId, string movieId, bool isWatched);
    }
}
