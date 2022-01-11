using BookAndMovie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndMovie.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> FindByIdAsync (string id);
        public Task<User> AddUserAsync(User newUser);
        public Task<User> GetUserByIdAsync (string id);
        public Task AddBookToLibraryById (string userId, string id);
        public Task DeleteBookFromUserListAsync(string userId, string id);
        public Task<IList<Book>> GetAllBooksByUserIdAsync(string id);
        public Task<IList<Book>> GetAllReadedBookByUserIdsAsync(string id);
        public Task<IList<Book>> GetAllUnreadedBookByUserIdsAsync(string id);
        public Task<Book> UpdateBookStatysByUserId(string userId, Book book);
        public Task<IList<Movie>> GetAllMovieByUserIdAsync(string id);
        public Task<IList<Movie>> GetAllWatchedMovieByUserIdsAsync(string id);
        public Task<IList<Movie>> GetAllUnwatchedMovieByUserIdsAsync(string id);
        public Task<Movie> UpdateMovieStatysByUserId(string userId, Movie movie);

    }
}
