using AutoMapper;
using BookAndMovie.Domain;
using BookAndMovie.Web.ViewModels.BookRating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndMovie.Web.AutoMapper
{
    public class BookRatingMapper : Profile
    {
        public BookRatingMapper()
        {
            CreateMap<CreateBookRatingViewModel, BooksRating>();
            CreateMap<BooksRating, CreateBookRatingViewModel>();
        }
    }
}
