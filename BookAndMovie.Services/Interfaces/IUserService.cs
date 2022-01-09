using BookAndMovie.Domain;
using System.Threading.Tasks;

namespace BookAndMovie.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> AddUserAsync(User newUser);
        public Task<User> GetUserByIdAsync(string id);
        //public Task<IList<Books>> GetAllUserBooks(string id);
        //public Task<IList<Movies>> GetAllUserMovies(string id);
        //public Task<IList<Series>> GetAllUserSeries(string id);

    }
}
