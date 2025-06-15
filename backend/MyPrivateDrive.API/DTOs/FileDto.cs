namespace MyPrivateDrive.API.DTOs
{
    public class FileDto
    {
        public int Id { get; set; }
        public string Filename { get; set; } = string.Empty;
        public long Size { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
