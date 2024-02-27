using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleTollApi.Application.TollPassages.Commands.Handlers;
using VehicleTollApi.Application.TollPassages.Queries.Handlers;
using VehicleTollApi.WebApi.Models;

namespace VehicleTollApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehiclePassagesController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehiclePassagesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetUnInvoicedByLicensePlateNumber([FromQuery]string licensePlateNumber, [FromQuery]DateTimeOffset untilDateTime, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetUnInvoicedByLicensePlateNumberQuery(licensePlateNumber, untilDateTime), cancellationToken);
        if (!result.IsValidResponse)
        {
            return BadRequest(result.Errors);
        }
        return Ok(result.Result);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetVehiclePassage(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetVehiclePassageByIdQuery(id), cancellationToken);
        if (!result.IsValidResponse)
        {
            return BadRequest(result.Errors);
        }
        return Ok(result.Result);
    }

    [HttpPost]
    public async Task<ActionResult> VehiclePassage([FromBody]VehiclePassageDTO vehiclePassage, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new AddVehiclePassageCommand(vehiclePassage.LicensePlateNumber, DateTimeOffset.Now), cancellationToken);
        if(!result.IsValidResponse)
        {
            return BadRequest(result.Errors);
        }
        var passage = result.Result;
        return CreatedAtAction(nameof(GetVehiclePassage), new { id = passage.Id }, new { id = passage.Id, passage });
    }
}
