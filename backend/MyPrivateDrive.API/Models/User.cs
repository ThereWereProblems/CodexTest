using System.ComponentModel.DataAnnotations;

namespace MyPrivateDrive.API.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        public List<FileRecord> Files { get; set; } = new();
    }
}
