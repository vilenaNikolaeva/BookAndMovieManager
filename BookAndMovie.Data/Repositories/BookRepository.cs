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
    }
}
