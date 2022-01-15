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
    public class UserRepository : BaseRepositoryContext, IUserRepository
    {
        public UserRepository(BookAndMovieDbContext context) : base(context) { }

        public async  Task<User> FindByIdAsync(string id)
        {
            return await this.context.Users.FindAsync(id);

        }

        public async Task<User> AddUserAsync (User newUser)
        {
            await this.context.Users.AddAsync(newUser);
            await this.context.SaveChangesAsync();
            return newUser;
        }

       
        public async Task<User> GetUserByIdAsync (string id)
        {
            var user = await this.FindByIdAsync(id);
            return user;
        }

        public async Task<BooksRating> AddBookRatingByUserAndBookId(BooksRating bookRating)
        {
            var user = await this.context.Users.Include(u => u.BooksRatings).SingleOrDefaultAsync(u => u.Id == bookRating.UserId);
            var bookAlreadyExist = user.BooksRatings.Where(u => u.BookId == bookRating.BookId && u.UserId == bookRating.UserId).SingleOrDefault();

            if (bookAlreadyExist == null)
            {
                bookRating.Id = Guid.NewGuid().ToString();
                user.BooksRatings.Add(bookRating);
            }
            else
            {
                bookAlreadyExist.Rating = bookRating.Rating;
            }

            var book = await this.context.Books.FindAsync(bookRating.BookId);
            if (book.Rating <= 0)
            {
                book.Rating = bookRating.Rating;
                book.RatingCount = book.RatingCount + 1;
            }
            else
            {
                book.Rating = book.Rating + bookRating.Rating;
                book.RatingCount = book.RatingCount + 1;
                book.Rating = Math.Round(book.Rating / book.RatingCount);
            }
            await this.context.SaveChangesAsync();
            return bookAlreadyExist;
        }
        public async Task AddBookToLibraryById(string userId, string id)
        {
            var book = await this.context.Books.FindAsync(id);
            var user = await this.context.Users.Include(u => u.Books).SingleOrDefaultAsync(u => u.Id == userId);
            user.Books.Add(book);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteBookFromUserListAsync(string userId, string id)
        {
            var book = await this.context.Books.FindAsync(id);
            var user = await this.context.Users.Include(u => u.Books).SingleOrDefaultAsync(u => u.Id == userId);
            user.Books.Remove(book);
            await this.context.SaveChangesAsync();
        }

        public async Task<IList<Book>> GetAllBooksByUserIdAsync(string id)
        {
            var userBooks = await this.context.Books.Where(b => b.Users.Select(u => u.Id).Contains(id)).ToListAsync();
            return userBooks;
        }

        public async Task<IList<Book>> GetAllReadedBookByUserIdsAsync(string id)
        {
            var readedBooks = await this.context.Books.Where(b => b.Users.Select(u => u.Id).Contains(id) && b.Readed == true).ToListAsync();
            return readedBooks;
        }

        public async Task<IList<Book>> GetAllUnreadedBookByUserIdsAsync(string id)
        {
            var unreadedBooks = await this.context.Books.Where(b => b.Users.Select(u => u.Id).Contains(id) && b.Readed == false).ToListAsync();
            return unreadedBooks;
        }

        public async Task<Book> UpdateBookStatysByUserId(string userId, Book book)
        {
            var currentBook = this.context.Books.FindAsync(book.Id);
            var user = await this.context.Users.Include(u => u.Books).SingleOrDefaultAsync(u => u.Id == userId );
            var bookForUpdate = user.Books.Where(i=>i.Id==book.Id).SingleOrDefault();
            bookForUpdate = book;
            this.context.Books.Update(bookForUpdate);
            await this.context.SaveChangesAsync();
            return bookForUpdate;
        }
          // <=========== MOVIE
        public async Task AddMovieToLibraryById(string userId, string id)
        {
            var movie = await this.context.Movies.FindAsync(id);
            var user = await this.context.Users.Include(u => u.Movies).SingleOrDefaultAsync(u => u.Id == userId);
            user.Movies.Add(movie);
            await this.context.SaveChangesAsync();
        }
        public async Task<IList<Movie>> GetAllMovieByUserIdAsync(string id)
        {
            var movies = await this.context.Movies.Where(b => b.Users.Select(u => u.Id).Contains(id)).ToListAsync();
            return movies;
        }

        public async Task<IList<Movie>> GetAllWatchedMovieByUserIdsAsync(string id)
        {
           var watchedMovies= await this.context.Movies.Where(b => b.Users.Select(u => u.Id).Contains(id) && b.Watched== true).ToListAsync();
            return watchedMovies;
        }

        public async Task<IList<Movie>> GetAllUnwatchedMovieByUserIdsAsync(string id)
        {
            var unwatchedMovies = await this.context.Movies.Where(b => b.Users.Select(u => u.Id).Contains(id) && b.Watched == false).ToListAsync();
            return unwatchedMovies;
        }

        public async Task<Movie> UpdateMovieStatysByUserId(string userId, Movie movie)
        {
            var currentMovie = this.context.Books.FindAsync(movie.Id);
            var user = await this.context.Users.Include(u => u.Movies).SingleOrDefaultAsync(u => u.Id == userId);
            var movieForUpdate = user.Movies.Where(i => i.Id == movie.Id).SingleOrDefault();
            movieForUpdate.Watched = movie.Watched;
            //this.context.Movies.Update(movieForUpdate); //????????
            await this.context.SaveChangesAsync();
            return movieForUpdate;
        }

        public async Task DeleteMovieFromUserListAsync(string userId, string id)
        {
            var movie = await this.context.Movies.FindAsync(id);
            var user = await this.context.Users.Include(u => u.Movies).SingleOrDefaultAsync(u => u.Id == userId);
            user.Movies.Remove(movie);
            await this.context.SaveChangesAsync();
        }

        public async Task<MoviesRating> AddMovieRatingByUserAndMovieId(MoviesRating movie)
        {
            var user = await this.context.Users.Include(u => u.MoviesRatings).SingleOrDefaultAsync(u => u.Id == movie.UserId);
            var movieForRate = user.MoviesRatings.Where(u => u.MovieId == movie.MovieId && u.UserId == movie.UserId).SingleOrDefault();

            if (movieForRate == null)
            {
                movie.Id = Guid.NewGuid().ToString();
                user.MoviesRatings.Add(movie);
            }
            else
            {
                movieForRate.Rating = movie.Rating;
            }

            var movieFromCatalog = await this.context.Movies.FindAsync(movie.MovieId);
            if (movieFromCatalog.Rating <= 0)
            {
                movieFromCatalog.Rating = movie.Rating;
                movieFromCatalog.RatingCount = movieFromCatalog.RatingCount + 1;
            }
            else
            {
                movieFromCatalog.Rating = movieFromCatalog.Rating + movie.Rating;
                movieFromCatalog.RatingCount = movieFromCatalog.RatingCount + 1;
                movieFromCatalog.Rating = Math.Round(movieFromCatalog.Rating / movieFromCatalog.RatingCount);
            }
            await this.context.SaveChangesAsync();
            return movieForRate;
        }
    }
}
