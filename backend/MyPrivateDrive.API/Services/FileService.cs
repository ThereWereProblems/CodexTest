using Microsoft.EntityFrameworkCore;
using MyPrivateDrive.API.Data;
using MyPrivateDrive.API.DTOs;
using MyPrivateDrive.API.Models;

namespace MyPrivateDrive.API.Services
{
    public class FileService
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _env;

        public FileService(ApplicationDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public async Task<IEnumerable<FileDto>> GetFilesAsync(int userId)
        {
            return await _db.Files.Where(f => f.UserId == userId)
                .Select(f => new FileDto { Id = f.Id, Filename = f.Filename, Size = f.Size, UploadDate = f.UploadDate })
                .ToListAsync();
        }

        public async Task<FileRecord?> SaveFileAsync(int userId, IFormFile file)
        {
            var uploads = Path.Combine(_env.ContentRootPath, "uploads");
            Directory.CreateDirectory(uploads);
            var filePath = Path.Combine(uploads, Path.GetRandomFileName());

            using (var stream = File.Create(filePath))
            {
                await file.CopyToAsync(stream);
            }

            var record = new FileRecord
            {
                Filename = file.FileName,
                Path = filePath,
                Size = file.Length,
                UploadDate = DateTime.UtcNow,
                UserId = userId
            };
            _db.Files.Add(record);
            await _db.SaveChangesAsync();
            return record;
        }

        public async Task<FileRecord?> GetFileAsync(int id, int userId)
        {
            return await _db.Files.FirstOrDefaultAsync(f => f.Id == id && f.UserId == userId);
        }

        public async Task DeleteFileAsync(FileRecord record)
        {
            if (File.Exists(record.Path))
                File.Delete(record.Path);
            _db.Files.Remove(record);
            await _db.SaveChangesAsync();
        }
    }
}
