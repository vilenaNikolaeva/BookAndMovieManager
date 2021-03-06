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
        public async Task<ActionResult> CreateBookAsync (CreateBookViewModel book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newBook = this.mapper.Map<Book>(book);
            await this.bookService.CreateBook(newBook);
            var bookViewModel = this.mapper.Map<BookViewModel>(newBook);

            return CreatedAtRoute("GetBookById", new { id = bookViewModel.Id }, bookViewModel);
        }

        //[HttpPost("{id}")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult> CreateBook(CreateBookViewModel book)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var newBook = this.mapper.Map<Book>(book);
        //    await this.bookService.CreateBook(newBook);
        //    var bookViewModel = this.mapper.Map<BookViewModel>(newBook);

        //    return CreatedAtRoute("GetBookById", new { id = bookViewModel.Id }, bookViewModel); ;
        //}

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

    }
}
