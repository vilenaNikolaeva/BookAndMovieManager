using BookAndMovie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookAndMovie.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<User> FindByIdAsync (string id);
        public Task<User> AddUserAsync(User newUser);
        public Task<User> GetUserByIdAsync (string id);
    }
}
