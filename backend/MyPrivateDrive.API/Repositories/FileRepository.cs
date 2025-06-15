using Microsoft.EntityFrameworkCore;
using MyPrivateDrive.API.Data;
using MyPrivateDrive.API.Models;

namespace MyPrivateDrive.API.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly ApplicationDbContext _db;

        public FileRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<FileRecord>> GetFilesAsync(int userId)
        {
            return await _db.Files.Where(f => f.UserId == userId).ToListAsync();
        }

        public async Task<FileRecord?> GetByIdAsync(int id, int userId)
        {
            return await _db.Files.FirstOrDefaultAsync(f => f.Id == id && f.UserId == userId);
        }

        public async Task AddAsync(FileRecord record)
        {
            _db.Files.Add(record);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(FileRecord record)
        {
            _db.Files.Remove(record);
            await _db.SaveChangesAsync();
        }
    }
}
