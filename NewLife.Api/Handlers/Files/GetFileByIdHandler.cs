using MediatR;
using Microsoft.EntityFrameworkCore;
using NewLife.Api.Queries.Files;
using NewLife.DataAccess.Data;

namespace NewLife.Api.Handlers.Files;

public class GetFileByIdHandler : IRequestHandler<GetFileByIdQuery, byte[]?>
{

  private readonly AppDbContext _context;

  public GetFileByIdHandler(AppDbContext context)
  {
    _context = context;
  }

  public async Task<byte[]?> Handle(GetFileByIdQuery request, CancellationToken cancellationToken)
  {
    var file = await _context.Files
      .FirstOrDefaultAsync(p => p.Id == request.Id);

    if (file == null)
    {
      return null;
    }

    // TODO: Why trim?????????
    var path = Path.Combine(Directory.GetCurrentDirectory(), file.FilePath.Trim('"'));

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