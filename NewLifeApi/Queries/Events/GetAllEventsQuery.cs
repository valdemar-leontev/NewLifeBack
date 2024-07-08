using MediatR;
using NewLifeDAL.DataModels;

namespace NewLifeApi.Queries.Events;

public class GetAllEventsQuery : IRequest<List<EventDataModel>> { }