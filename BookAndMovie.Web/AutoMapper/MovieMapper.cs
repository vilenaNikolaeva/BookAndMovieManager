using AutoMapper;
using BookAndMovie.Domain;
using BookAndMovie.Web.ViewModels.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAndMovie.Web.AutoMapper
{
    public class MovieMapper : Profile
    {
        public MovieMapper()
        {
            CreateMap<Movie, MovieViewModel>();
            CreateMap<MovieViewModel, Movie>();
            CreateMap<CreateMovieViewModel, Movie>();
            CreateMap<Movie, CreateMovieViewModel>();
        }
    }
}
