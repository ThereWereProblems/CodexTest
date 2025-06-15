using MyPrivateDrive.API.Models;

namespace MyPrivateDrive.API.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
    }
}
