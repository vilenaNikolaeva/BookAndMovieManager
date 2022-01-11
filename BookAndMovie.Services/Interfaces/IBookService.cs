using BookAndMovie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndMovie.Services.Interfaces
{
    public interface IBookService
    {
        public Task<Book> FindByIdAsync(string id);
        public Task<Book> CreateBook(Book book);
        public Task<IList<Book>> GetAllBooksAsync();

    }
}
