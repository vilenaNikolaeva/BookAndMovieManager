using AutoMapper;
using BookAndMovie.Domain;
using BookAndMovie.Web.ViewModels.MovieRating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndMovie.Web.AutoMapper
{
    public class MovieRatingViewModel : Profile
    {
        public MovieRatingViewModel()
        {
            CreateMap<CreateMovieRatingViewModel, MoviesRating>();
            CreateMap<MoviesRating, CreateMovieRatingViewModel>();
        }
    }
}
