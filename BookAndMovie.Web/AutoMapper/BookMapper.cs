using AutoMapper;
using BookAndMovie.Domain;
using BookAndMovie.Web.ViewModels.Book;

namespace BookAndMovie.Web.AutoMapper
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<Book, CreateBookViewModel>();
            CreateMap<CreateBookViewModel, Book>();
            CreateMap<Book, BookViewModel>();
            CreateMap<BookViewModel, Book>();
        }
    }
}
