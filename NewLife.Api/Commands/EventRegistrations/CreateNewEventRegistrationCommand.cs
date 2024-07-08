using MediatR;
using NewLife.DataAccess.DataModels;

namespace NewLife.Api.Commands.EventRegistrations;

public class CreateNewEventRegistrationCommand : EventRegistrationModel, IRequest<EventRegistrationDataModel> { }
