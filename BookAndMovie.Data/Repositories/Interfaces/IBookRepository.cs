using BookAndMovie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndMovie.Data.Repositories.Interfaces
{
    public interface IBookRepository
    {
        public Task<Book> FindByIdAsync(string id);
        public Task<Book> CreateBook(Book book);
        public Task<IList<Book>> GetAllBooksAsync();
    }
}
