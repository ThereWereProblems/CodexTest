using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyPrivateDrive.API.Models
{
    public class FileRecord
    {
        public int Id { get; set; }
        [Required]
        public string Filename { get; set; } = string.Empty;
        [Required]
        public string Path { get; set; } = string.Empty;
        public long Size { get; set; }
        public DateTime UploadDate { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
