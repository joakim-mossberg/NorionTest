using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleTollApi.Application.TollPassages.Commands.Handlers;

namespace VehicleTollApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TollPassagesController : ControllerBase
{
    private readonly IMediator _mediator;

    public TollPassagesController(IMediator mediator) => _mediator = mediator;

    [HttpPost("vehicle")]
    public async Task<IActionResult> VehiclePassage(string licensePlateNumber)
    {
        var result = await _mediator.Send(new AddVehiclePassageCommand(licensePlateNumber));
        return Ok();
    }
}
