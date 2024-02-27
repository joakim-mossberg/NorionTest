using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleTollApi.Application.TollPassages.Commands.Handlers;
using VehicleTollApi.Application.TollPassages.Queries.Handlers;
using VehicleTollApi.WebApi.Models;

namespace VehicleTollApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TollPassagesController : ControllerBase
{
    private readonly IMediator _mediator;

    public TollPassagesController(IMediator mediator) => _mediator = mediator;

    [HttpGet("licenseplatenumber")]
    public async Task<IActionResult> GetUnInvoicedByLicensePlateNumber(string licensePlateNumber, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetUnInvoicedByLicensePlateNumberQuery(licensePlateNumber), cancellationToken);
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
