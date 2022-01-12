using BookAndMovie.Services.Interfaces;
using BookAndMovie.Domain;
using System;
using System.Threading.Tasks;
using BookAndMovie.Data.Repositories.Interfaces;
using System.Collections.Generic;

namespace BookAndMovie.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<User> GetUserByIdAsync(string id)
        {
            return await this.userRepository.GetUserByIdAsync(id);
        }
        public async Task AddBookToLibraryById(string userId, string id)
        {
            await this.userRepository.AddBookToLibraryById(userId, id);
        }

        public async Task<User> AddUserAsync(User newUser)
        {
            await this.userRepository.AddUserAsync(newUser);
            return newUser;
        }

        public async Task DeleteBookFromUserListAsync(string userId, string id)
        {
             await this.userRepository.DeleteBookFromUserListAsync(userId, id);
        }
        public async Task<IList<Book>> GetAllBooksByUserIdAsync(string id)
        {
            var userBooks = await this.userRepository.GetAllBooksByUserIdAsync(id);
            return userBooks;
        }

        public async Task<IList<Book>> GetAllReadedBookByUserIdsAsync(string id)
        {
            var readedBooks = await this.userRepository.GetAllReadedBookByUserIdsAsync(id);
            return readedBooks;
        }

        public async Task<IList<Book>> GetAllUnreadedBookByUserIdsAsync(string id)
        {
            var unreadedBooks = await this.userRepository.GetAllUnreadedBookByUserIdsAsync(id);
            return unreadedBooks;
        }


        public async Task<Book> UpdateBookStatysByUserId(string userId, Book book)
        {
            var updatedBookStatus = await this.userRepository.UpdateBookStatysByUserId(userId, book);
            return updatedBookStatus;
        }
        public async Task AddMovieToLibraryById(string userId, string id)
        {
             await this.userRepository.AddMovieToLibraryById(userId, id);
        }
        public async  Task<IList<Movie>> GetAllMovieByUserIdAsync(string id)
        {
           return await this.userRepository.GetAllMovieByUserIdAsync(id);
        }

        public async Task<IList<Movie>> GetAllWatchedMovieByUserIdsAsync(string id)
        {
            return await this.userRepository.GetAllWatchedMovieByUserIdsAsync(id);
        }

        public async Task<IList<Movie>> GetAllUnwatchedMovieByUserIdsAsync(string id)
        {
            return await this.userRepository.GetAllUnwatchedMovieByUserIdsAsync(id);
        }

        public Task<Movie> UpdateMovieStatysByUserId(string userId, Movie movie)
        {
            return this.userRepository.UpdateMovieStatysByUserId(userId, movie);
        }

        public async Task DeleteMovieFromUserListAsync(string userId, string id)
        {
            await this.userRepository.DeleteMovieFromUserListAsync(userId, id);
        }
    }
}
