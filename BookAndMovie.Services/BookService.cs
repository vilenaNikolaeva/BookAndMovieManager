using BookAndMovie.Data.Repositories.Interfaces;
using BookAndMovie.Domain;
using BookAndMovie.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAndMovie.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async  Task<Book> CreateBook(Book book)
        {
            return  await this.bookRepository.CreateBook(book);
        }

        public async Task<Book> FindByIdAsync(string id)
        {
            return await this.bookRepository.FindByIdAsync(id);
        }

        public async Task<IList<Book>> GetAllBooksAsync()
        {
            var allBooks = await this.bookRepository.GetAllBooksAsync();
            return allBooks;
        }

        
    }
}
