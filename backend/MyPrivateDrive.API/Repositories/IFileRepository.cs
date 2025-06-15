using MyPrivateDrive.API.Models;

namespace MyPrivateDrive.API.Repositories
{
    public interface IFileRepository
    {
        Task<IEnumerable<FileRecord>> GetFilesAsync(int userId);
        Task<FileRecord?> GetByIdAsync(int id, int userId);
        Task AddAsync(FileRecord record);
        Task DeleteAsync(FileRecord record);
    }
}
