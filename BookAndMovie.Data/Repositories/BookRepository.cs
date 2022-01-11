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
    public class BookRepository : BaseRepositoryContext, IBookRepository
    {
        public BookRepository(BookAndMovieDbContext context) : base(context)
        {
        }

       

        public async Task<Book> CreateBook(Book book)
        {
            var guid = Guid.NewGuid();
            book.Id = guid.ToString();
            await this.context.Books.AddAsync(book);
            await this.context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> FindByIdAsync(string id)
        {
            return await this.context.Books.FindAsync(id);
        }

        public async Task<IList<Book>> GetAllBooksAsync()
        {
            var books = await this.context.Books.ToListAsync();
            return books;
        }

        public async Task<IList<Book>> GetAllBooksByUserIdAsync(string id)
        {
            var userBooks = await this.context.Books.Where(b => b.Users.Select(u=>u.Id).Contains(id)).ToListAsync();
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
            var bookForUpdate = await this.FindByIdAsync(book.Id);
            bookForUpdate.Readed = book.Readed;
            this.context.Books.Update(bookForUpdate);
            await this.context.SaveChangesAsync();
            return bookForUpdate;
        }
      
    }
}
