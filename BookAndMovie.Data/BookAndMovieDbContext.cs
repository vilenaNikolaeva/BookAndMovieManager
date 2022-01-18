using BookAndMovie.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace BookAndMovie.Data
{
    public class BookAndMovieDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<Book> Books{ get; set; }
        public DbSet<Movie> Movies { get; set; }

        public BookAndMovieDbContext(DbContextOptions<BookAndMovieDbContext> contextOptions)
           : base(contextOptions)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
