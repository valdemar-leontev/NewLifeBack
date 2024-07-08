using MediatR;
using Microsoft.EntityFrameworkCore;
using NewLifeApi.Queries.Events;
using NewLifeDAL.DataModels;
using NewLifeDataAccess.Data;

namespace NewLifeApi.Handlers.Events;

public class GetAllEventsHandler : IRequestHandler<GetAllEventsQuery, List<EventDataModel>>
{
  private readonly AppDbContext _context;

  public GetAllEventsHandler(AppDbContext context)
  {
    _context = context;
  }

  public async Task<List<EventDataModel>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
  {
    return await _context.Events
      .Include(e => e.File)
      .Include(e => e.EventRegistrations)
      .AsNoTracking()
      .ToListAsync(cancellationToken);
  }
}
