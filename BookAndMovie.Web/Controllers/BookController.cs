using AutoMapper;
using BookAndMovie.Domain;
using BookAndMovie.Services.Interfaces;
using BookAndMovie.Web.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndMovie.Web.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookService;
        private readonly IMapper mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetBookById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get(string id)
        {
            var book = await this.bookService.FindByIdAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            var bookViewModel = this.mapper.Map<BookViewModel>(book);

            return Ok(bookViewModel);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateBook(CreateBookViewModel book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newBook = this.mapper.Map<Book>(book);
            await this.bookService.CreateBook(newBook);
            var bookViewModel = this.mapper.Map<CreateBookViewModel>(newBook);

            return CreatedAtRoute("GetBookById", new { id = bookViewModel.Id }, bookViewModel); ;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllBooks()
        {
            var allBooks = await this.bookService.GetAllBooksAsync();

            if (allBooks.Count == 0)
            {
                return NotFound();
            }

            var booksViewModels = this.mapper.Map<IList<BookViewModel>>(allBooks);

            return Ok(booksViewModels);
        }

        [HttpGet]
        [Route("allUserBooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllBooksByUserIdAsync(string id)
        {
            var userBookd = await this.bookService.GetAllBooksByUserIdAsync(id);

            if (userBookd == null)
            {
                return NotFound();
            }

            var booksViewModels = this.mapper.Map<CreateBookViewModel>(userBookd);

            return Ok(booksViewModels);
        }

        [HttpGet]
        [Route("readedUserBooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllReadedBookByUserIdsAsync(string id)
        {
            var readedBooks = await this.bookService.GetAllReadedBookByUserIdsAsync(id);

            if (readedBooks == null)
            {
                return NotFound();
            }

            var booksViewModels = this.mapper.Map<CreateBookViewModel>(readedBooks);

            return Ok(booksViewModels);
        }

        [HttpGet]
        [Route("unreadedUserBooks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetAllUnreadedBookByUserIdsAsync(string id)
        {
            var unreadedBooks = await this.bookService.GetAllUnreadedBookByUserIdsAsync(id);

            if (unreadedBooks == null)
            {
                return NotFound();
            }

            var booksViewModels = this.mapper.Map<CreateBookViewModel>(unreadedBooks);

            return Ok(booksViewModels);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateBookStatysByUserId(string userId, Book book)
        {
            var updatedBook = await this.bookService.UpdateBookStatysByUserId(userId,book);

            if (updatedBook == null)
            {
                return NotFound();
            }

            var booksViewModels = this.mapper.Map<CreateBookViewModel>(updatedBook);

            return Ok(booksViewModels);
        }
    }
}
