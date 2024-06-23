using MediatR;
using Microsoft.EntityFrameworkCore;
using NewLifeApi.Queries;
using NewLifeDataAccess.Data;

namespace NewLifeApi.Handlers;

public class GetPhotoByIdHandler : IRequestHandler<GetPhotoByIdQuery, byte[]?>
{

  private readonly AppDbContext _context;

  public GetPhotoByIdHandler(AppDbContext context)
  {
    _context = context;
  }

  public async Task<byte[]?> Handle(GetPhotoByIdQuery request, CancellationToken cancellationToken)
  {
    var photo = await _context.Photos
        .FirstOrDefaultAsync(p => p.Id == request.Id);

    if (photo == null)
    {
      return null;
    }

    // TODO: Why trim?????????
    var path = Path.Combine(Directory.GetCurrentDirectory(), photo.FilePath.Trim('"'));

    try
    {
      return await File.ReadAllBytesAsync(path);
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Error reading file: {ex.Message}");
      throw;
    }
  }
}