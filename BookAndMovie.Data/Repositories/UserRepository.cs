﻿using BookAndMovie.Data.Repositories.Interfaces;
using BookAndMovie.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndMovie.Data.Repositories
{
    public class UserRepository : BaseRepositoryContext, IUserRepository
    {
        public UserRepository(BookAndMovieDbContext context) : base(context) { }

        public async  Task<User> FindByIdAsync(string id)
        {
            return await this.context.Users.FindAsync(id);

        }

        public async Task<User> AddUserAsync (User newUser)
        {
            await this.context.Users.AddAsync(newUser);
            await this.context.SaveChangesAsync();
            return newUser;
        }

       
        public async Task<User> GetUserByIdAsync (string id)
        {
            var user = await this.FindByIdAsync(id);
            return user;
        }
    }
}