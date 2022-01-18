using BookAndMovie.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndMovie.Data
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                 .HasData(
                     new Book
                     {
                         Id = "4c400974 - ff7a - 449f - 8843 - 453e49c11vili",
                         Title = "Вълкът и седемте козлета",
                         Author = " Братя Грим",
                         BookImageUrl = "https://firebasestorage.googleapis.com/v0/b/booksandmovies-cf479.appspot.com/o/booksImages%2Fvylkyt-i-sedemte-kozleta-prikazki-v-rimi.jpg?alt=media&token=bf196422-590c-4f7b-b083-b0ef328513e4",
                         BookFileUrl = "https://firebasestorage.googleapis.com/v0/b/booksandmovies-cf479.appspot.com/o/books%2FBruder-Grimm_-_Vylkyt_i_sedemte_kozleta_-_48618.pdf?alt=media&token=9fdff897-1a1f-4640-860d-54bebde2f3e4",
                         Readed = false,
                         Rating = 5,
                         RatingCount = 5,
                         Users = new List<User>(),
                     },
                     new Book
                     {
                         Id = "4c400974 - ff7a - 449f - 8843 - 453e49c12vili",
                         Title = "Рапунцел",
                         Author = " Братя Грим",
                         BookImageUrl = "https://firebasestorage.googleapis.com/v0/b/booksandmovies-cf479.appspot.com/o/booksImages%2Frapunzel1482485405.177.jpg?alt=media&token=77b77503-4ae1-4579-996b-69023aa9605e",
                         BookFileUrl = "https://firebasestorage.googleapis.com/v0/b/booksandmovies-cf479.appspot.com/o/books%2FBruder-Grimm_-_Rumpelshtiltshen_-_48620.pdf?alt=media&token=c0ee9ebf-1e0b-4c96-ab5b-4b4c1745e96f",
                         Readed = false,
                         Rating = 5,
                         RatingCount = 7,
                         Users = new List<User>(),
                     },
                        new Book
                        {
                            Id = "4c400974 - ff7a - 449f - 8843 - 453e49c13vili",
                            Title = "Монахът който продаде своето ферари",
                            Author = " Робин Шарма",
                            BookImageUrl = "https://firebasestorage.googleapis.com/v0/b/booksandmovies-cf479.appspot.com/o/booksImages%2F9789548208529.jpg?alt=media&token=25d8b8d5-8893-40d8-9a39-fb461dfcb94b",
                            BookFileUrl = "https://firebasestorage.googleapis.com/v0/b/booksandmovies-cf479.appspot.com/o/books%2F%D0%9C%D0%BE%D0%BD%D0%B0%D1%85%D1%8A%D1%82-%D0%BA%D0%BE%D0%B8%CC%86%D1%82%D0%BE-%D0%BF%D1%80%D0%BE%D0%B4%D0%B0%D0%B4%D0%B5-%D1%81%D0%B2%D0%BE%D0%B5%D1%82%D0%BE-%D1%84%D0%B5%D1%80%D0%B0%D1%80%D0%B8.pdf?alt=media&token=f087d015-7b14-436b-a379-25503a5e18ed",
                            Readed = false,
                            Rating = 4,
                            RatingCount = 5,
                            Users = new List<User>(),
                        },
                        new Book
                        {
                            Id = "4c400974 - ff7a - 449f - 8843 - 453e49c14vili",
                            Title = "Мисли и забогатявай",
                            Author = " Наполеон Хил",
                            BookImageUrl = "https://firebasestorage.googleapis.com/v0/b/booksandmovies-cf479.appspot.com/o/booksImages%2Fmisli-i-zabogatyavay-30.jpg?alt=media&token=24f26e78-390b-4dfc-93ee-5dae0ade717e",
                            BookFileUrl = "https://firebasestorage.googleapis.com/v0/b/booksandmovies-cf479.appspot.com/o/books%2FMisli_i_zabogatqvaj.pdf?alt=media&token=b87fcaa7-aad8-4b03-837d-1706c1448485",
                            Readed = false,
                            Rating = 4,
                            RatingCount = 5,
                            Users = new List<User>(),
                        },
                        new Book
                        {
                            Id = "4c400974 - ff7a - 449f - 8843 - 453e49c16vili",
                            Title = "The Awakening",
                            Author = "Nora Roberts",
                            BookImageUrl = "https://firebasestorage.googleapis.com/v0/b/booksandmovies-cf479.appspot.com/o/booksImages%2Fdownload.jfif?alt=media&token=7eeaa3ac-7788-4496-a1d7-759a09c627df",
                            BookFileUrl = "https://firebasestorage.googleapis.com/v0/b/booksandmovies-cf479.appspot.com/o/books%2FThe%20Awakening%20by%20Nora%20Roberts.pdf?alt=media&token=48e1b190-2a7e-4de5-abe1-cd54b72d5757",
                            Readed = false,
                            Rating = 3,
                            RatingCount = 5,
                            Users = new List<User>(),
                        }
                 );
            modelBuilder.Entity<Movie>()
                .HasData(
                    new Movie
                    {
                        Id = "4m400974 - ff7a - 449f - 8843 - 453e49c11vili",
                        Title = "Avengers",
                        FilmGenre = "Action, Adventure, Fantasy",
                        MovieImageUrl = "https://firebasestorage.googleapis.com/v0/b/booksandmovies-cf479.appspot.com/o/moviesImages%2Favengers.jpg?alt=media&token=e600fa19-e3cf-4be2-b303-110ad5b549ee",
                        MovieUrl = "https://www.youtube.com/watch?v=eOrNdBpGMv8",
                        Watched = false,
                        Rating = 5,
                        RatingCount = 7,
                        Users = new List<User>(),
                    },
                    new Movie
                    {
                        Id = "5m400974 - ff7a - 449f - 8843 - 453e49c12vili",
                        Title = "Love Hard",
                        FilmGenre = "Comedy",
                        MovieImageUrl = "https://firebasestorage.googleapis.com/v0/b/booksandmovies-cf479.appspot.com/o/moviesImages%2Fdetcwq9-f5478b3d-aa76-47bb-9d1d-7bc1c7ad112a.png?alt=media&token=a37b1212-b260-4d73-a35d-a71a3368fee4",
                        MovieUrl = "https://www.youtube.com/watch?v=3boMRfx6cjE",
                        Watched = false,
                        Rating = 3,
                        RatingCount = 3,
                        Users = new List<User>(),
                    },
                    new Movie
                    {
                        Id = "5m400974 - ff7a - 449f - 8843 - 453e49c13vili",
                        Title = "No Time To Die",
                        FilmGenre = "Action",
                        MovieImageUrl = "https://firebasestorage.googleapis.com/v0/b/booksandmovies-cf479.appspot.com/o/moviesImages%2Fjames-bond-no-time-to-die-2021.jpg?alt=media&token=b22816c0-4bc0-4149-aef2-b930804bafc0",
                        MovieUrl = "https://www.youtube.com/watch?v=BIhNsAtPbPI",
                        Watched = false,
                        Rating = 3,
                        RatingCount = 3,
                        Users = new List<User>(),
                    },
                    new Movie
                    {
                        Id = "5m400974 - ff7a - 449f - 8843 - 453e49c14vili",
                        Title = "Interstellar",
                        FilmGenre = "Fantasy, Adventure · Drama",
                        MovieImageUrl = "https://firebasestorage.googleapis.com/v0/b/booksandmovies-cf479.appspot.com/o/moviesImages%2FInterstellar_film_poster.jpg?alt=media&token=08e2f5b2-7af2-4062-9bb6-502e9f241bdd",
                        MovieUrl = "https://www.youtube.com/watch?v=zSWdZVtXT7E",
                        Watched = false,
                        Rating = 5,
                        RatingCount = 8,
                        Users = new List<User>(),
                    },
                    new Movie
                    {
                        Id = "5m400974 - ff7a - 449f - 8843 - 453e49c15vili",
                        Title = "Rons Gone Wrong",
                        FilmGenre = "Kids & family, Comedy, Animation",
                        MovieImageUrl = "https://firebasestorage.googleapis.com/v0/b/booksandmovies-cf479.appspot.com/o/moviesImages%2Frons-gone-wrong-2021.jpg?alt=media&token=93e57a6e-b4ca-4e86-8f3c-d1ff29a592c6",
                        MovieUrl = "https://www.youtube.com/watch?v=pZwVi79D3y0",
                        Watched = false,
                        Rating = 5,
                        RatingCount = 8,
                        Users = new List<User>(),
                    }
                );
        }
    }
}
