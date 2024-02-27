using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleTollApi.Application.TollPassages.Commands.Handlers;
using VehicleTollApi.WebApi.Models;

namespace VehicleTollApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TollPassagesController : ControllerBase
{
    private readonly IMediator _mediator;

    public TollPassagesController(IMediator mediator) => _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> VehiclePassage([FromBody]VehiclePassageDTO vehiclePassage, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new AddVehiclePassageCommand(vehiclePassage.LicensePlateNumber, DateTimeOffset.Now), cancellationToken);
        if(!result.IsValidResponse)
        {
            return BadRequest(result.Errors);
        }
        return Ok(result);
    }
}
