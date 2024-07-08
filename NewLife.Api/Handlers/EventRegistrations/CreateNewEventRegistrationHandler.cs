using MediatR;
using NewLife.Api.Commands.EventRegistrations;
using NewLife.DataAccess.DataModels;
using NewLife.DataAccess.Data;

namespace NewLife.Api.Handlers.EventRegistrations;

public class CreateNewEventRegistrationHandler : IRequestHandler<CreateNewEventRegistrationCommand, EventRegistrationDataModel>
{
  private readonly AppDbContext _context;

  public CreateNewEventRegistrationHandler(AppDbContext context)
  {
    _context = context;
  }

  public async Task<EventRegistrationDataModel> Handle(CreateNewEventRegistrationCommand request, CancellationToken cancellationToken)
  {
    var eventRegistration = new EventRegistrationDataModel
    {
      FirstName = request.FirstName,
      LastName = request.LastName,
      Surname = request.Surname,
      PhoneNumber = request.PhoneNumber,
      TelegramNickname = request.TelegramNickname,
      Email = request.Email,
      EventId = request.EventId
    };

    _context.EventRegistrations.Add(eventRegistration);
    await _context.SaveChangesAsync(cancellationToken);

    return eventRegistration;
  }
}
