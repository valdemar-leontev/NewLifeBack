using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewLifeApi.Queries;

namespace NewLifeApi.Controllers;

public class FileController : BaseController
{
  public FileController(IMediator mediator) : base(mediator) { }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetFileById(int id)
  {
    var imageBytes = await _mediator.Send(new GetFileByIdQuery(id));

    if (imageBytes == null)
    {
      return NotFound();
    }

    return File(imageBytes, "image/jpeg");
  }

  [HttpPost("upload")]
  public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
  {
    if (file == null || file.Length == 0)
    {
      return BadRequest("No file uploaded.");
    }

    var filePath = Path.Combine("uploads", file.FileName);

    Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

    using (var stream = new FileStream(filePath, FileMode.Create))
    {
      await file.CopyToAsync(stream);
    }

    return Ok(new { FilePath = filePath });
  }
}
