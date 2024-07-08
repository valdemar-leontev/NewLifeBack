using MediatR;
using Microsoft.EntityFrameworkCore;
using NewLifeApi.Queries;
using NewLifeApi.Queries.Files;
using NewLifeDataAccess.Data;

namespace NewLifeApi.Handlers.Files;

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