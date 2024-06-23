using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewLifeApi.Queries;

namespace NewLifeApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PhotosController : ControllerBase
{
  private readonly IMediator _mediator;

  public PhotosController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetPhotoById(int id)
  {
    var imageBytes = await _mediator.Send(new GetPhotoByIdQuery(id));

    if (imageBytes == null)
    {
      return NotFound();
    }

    return File(imageBytes, "image/jpeg");
  }

  [HttpPost("upload")]
  public async Task<IActionResult> UploadPhoto([FromForm] IFormFile file)
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
