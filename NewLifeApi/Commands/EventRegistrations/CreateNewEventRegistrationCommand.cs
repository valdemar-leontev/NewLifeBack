using MediatR;
using NewLifeDAL.DataModels;

namespace NewLifeApi.Commands.EventRegistrations;

public class CreateNewEventRegistrationCommand : EventRegistrationModel, 
                                                 IRequest<EventRegistrationDataModel> { }
