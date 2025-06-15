using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPrivateDrive.API.DTOs;
using MyPrivateDrive.API.Services;
using System.Security.Claims;

namespace MyPrivateDrive.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("files")]
    public class FilesController : ControllerBase
    {
        private readonly FileService _fileService;

        public FilesController(FileService fileService)
        {
            _fileService = fileService;
        }

        private int GetUserId() => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FileDto>>> GetFiles()
        {
            var files = await _fileService.GetFilesAsync(GetUserId());
            return Ok(files);
        }

        [HttpPost("upload")]
        [RequestSizeLimit(10485760)] // 10MB
        public async Task<IActionResult> Upload([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest();
            var record = await _fileService.SaveFileAsync(GetUserId(), file);
            return Ok(new { record.Id });
        }

        [HttpGet("{id}/download")]
        public async Task<IActionResult> Download(int id)
        {
            var record = await _fileService.GetFileAsync(id, GetUserId());
            if (record == null)
                return NotFound();
            var bytes = await System.IO.File.ReadAllBytesAsync(record.Path);
            return File(bytes, "application/octet-stream", record.Filename);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _fileService.GetFileAsync(id, GetUserId());
            if (record == null)
                return NotFound();
            await _fileService.DeleteFileAsync(record);
            return NoContent();
        }
    }
}
