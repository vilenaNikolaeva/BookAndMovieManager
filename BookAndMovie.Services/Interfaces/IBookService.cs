﻿using BookAndMovie.Domain;
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
        public Task<IList<Book>> GetAllBooksByUserIdAsync(string id);
        public Task<IList<Book>> GetAllReadedBookByUserIdsAsync(string id);
        public Task<IList<Book>> GetAllUnreadedBookByUserIdsAsync(string id);
        public Task<Book> UpdateBookStatysByUserId(string userId, Book book);

    }
}