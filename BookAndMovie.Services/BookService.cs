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

        public async Task<IList<Book>> GetAllBooksByUserIdAsync(string id)
        {
            var userBooks = await this.bookRepository.GetAllBooksByUserIdAsync(id);
            return userBooks;
        }

        public  async Task<IList<Book>> GetAllReadedBookByUserIdsAsync(string id)
        {
            var readedBooks = await this.bookRepository.GetAllReadedBookByUserIdsAsync(id);
            return readedBooks;
        }

        public async Task<IList<Book>> GetAllUnreadedBookByUserIdsAsync(string id)
        {
            var unreadedBooks = await this.bookRepository.GetAllUnreadedBookByUserIdsAsync(id);
            return unreadedBooks;
        }

        public async Task<Book> UpdateBookStatysByUserId(string userId, Book book)
        {
            var updatedBookStatus = await this.bookRepository.UpdateBookStatysByUserId(userId, book);
            return updatedBookStatus;
        }
    }
}
