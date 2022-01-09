using BookAndMovie.Services.Interfaces;
using BookAndMovie.Domain;
using System;
using System.Threading.Tasks;
using BookAndMovie.Data.Repositories.Interfaces;

namespace BookAndMovie.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> AddUserAsync(User newUser)
        {
            await this.userRepository.AddUserAsync(newUser);
            return newUser;
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            var user= await this.userRepository.GetUserByIdAsync(id);
            return user;
        }
    }
}
