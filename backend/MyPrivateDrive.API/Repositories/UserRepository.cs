using Microsoft.EntityFrameworkCore;
using MyPrivateDrive.API.Data;
using MyPrivateDrive.API.Models;

namespace MyPrivateDrive.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _db.Users.SingleOrDefaultAsync(u => u.Username == username);
        }
    }
}
