using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleTollApi.Application.VehicleOwners.Queries.Handlers;
using VehicleTollApi.Application.Vehicles.Commands.Handlers;
using VehicleTollApi.Application.Vehicles.Queries.Handlers;
using VehicleTollApi.WebApi.Models;

namespace VehicleTollApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehiclesController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehiclesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAllVehicles()
    {
        var result = await _mediator.Send(new GetAllVehiclesQuery());
        if (!result.IsValidResponse)
        {
            return BadRequest(result.Errors);
        }
        return Ok(result.Result);
    }

    [HttpGet("licenseplatenumber")]
    public async Task<IActionResult> GetVehicleByLicensePlate(string licensePlateNumber, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetVehiclesByLicensePlateQuery(licensePlateNumber), cancellationToken);
        if (!result.IsValidResponse)
        {
            return BadRequest(result.Errors);
        }
        return Ok(result.Result);
    }

    [HttpPost("newvehicle")]
    public async Task<ActionResult<NewVehicleDTO>> CreateVehicle([FromBody]NewVehicleDTO vehicle, CancellationToken cancellationToken)
    {
        var ownerResult = await _mediator.Send(new GetVehicleOwnerByIdQuery(vehicle.OwnerId), cancellationToken);
        if(!ownerResult.IsValidResponse)
        {
            return BadRequest(ownerResult.Errors);
        }
        if(ownerResult.Result is null)
        {
            return BadRequest($"No owner found for Id: {vehicle.OwnerId}");
        }
        var owner = ownerResult.Result;
        var result = await _mediator.Send(new CreateVehicleCommand(owner.Id, vehicle.LicensePlate, vehicle.VehicleKind), cancellationToken);
        if(!result.IsValidResponse)
        {
            return BadRequest(result.Errors);
        }
        var newVehicle = result.Result;
        return CreatedAtAction(nameof(GetVehicleByLicensePlate), new { licensePlateNumber = newVehicle.LicensePlateNumber }, new { Id = newVehicle.LicensePlateNumber, newVehicle });
    }
}
