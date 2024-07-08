using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewLife.Api.Queries.Events;

namespace NewLife.Api.Controllers;

public class EventController : BaseController
{
  public EventController(IMediator mediator) : base(mediator) { }

  [HttpGet]
  public async Task<IActionResult> GetAllAsync()
  {
    var events = await _mediator.Send(new GetAllEventsQuery());

    if (events == null || events.Count == 0)
    {
      return NotFound();
    }

    return Ok(events);
  }
}
