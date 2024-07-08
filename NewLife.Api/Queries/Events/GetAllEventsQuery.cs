using MediatR;
using NewLife.DataAccess.DataModels;

namespace NewLife.Api.Queries.Events;

public class GetAllEventsQuery : IRequest<List<EventDataModel>> { }