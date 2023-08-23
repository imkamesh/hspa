using PropertyAPI.Models;

namespace PropertyAPI.Interfaces
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string username, string password);
    }
}
