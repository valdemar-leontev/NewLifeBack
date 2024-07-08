using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewLife.Api.Commands.EventRegistrations;

namespace NewLife.Api.Controllers;

public class EventRegistrationController : BaseController
{
  public EventRegistrationController(IMediator mediator) : base(mediator) { }

  [HttpPost("create")]
  public async Task<IActionResult> CreateAsync([FromBody] CreateNewEventRegistrationCommand model)
  {
    try
    {
      if (!EmailHelper.IsValid(model.Email))
      {
        return BadRequest("Email is invalid");
      }

      var eventRegistrationList = await _mediator.Send(model);

      if (eventRegistrationList is null)
      {
        return NotFound();
      }

      return Ok(eventRegistrationList);
    }
    catch (Exception)
    {
      return BadRequest("Internal server error.");
    }
  }
}
