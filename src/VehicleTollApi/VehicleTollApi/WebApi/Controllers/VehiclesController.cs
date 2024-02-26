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
    public async Task<ActionResult<IEnumerable<VehicleDTO>>> GetAllVehicles()
    {
        var result = await _mediator.Send(new GetAllVehiclesQuery());
        return Ok(result);
    }

    [HttpGet("licenseplatenumber")]
    public async Task<ActionResult<VehicleDTO>> GetVehicleByLicensePlate(string licensePlateNumber, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetVehiclesByLicensePlateQuery(licensePlateNumber), cancellationToken);
        return Ok(result);
    }

    [HttpPost("newvehicle")]
    public async Task<ActionResult<VehicleDTO>> CreateVehicle([FromBody]VehicleDTO vehicle, CancellationToken cancellationToken)
    {
        var ownerResult = await _mediator.Send(new GetVehicleOwnerByLicensePlateQuery(vehicle.LicensePlate), cancellationToken);
        if(!ownerResult.IsValidResponse)
        {
            return BadRequest(ownerResult.Errors);
        }
        if(ownerResult.Result is null)
        {
            return BadRequest($"No owner found for vehicle: {vehicle.LicensePlate}");
        }
        var owner = ownerResult.Result;
        var result = await _mediator.Send(new CreateVehicleCommand(owner.Id, vehicle.LicensePlate, vehicle.VehicleKind), cancellationToken);
        if(result.IsValidResponse)
        {
            return BadRequest(result.Errors);
        }
        var newVehicle = result.Result;
        return CreatedAtAction(nameof(CreateVehicle), new { licensePlateNumber = newVehicle.LicensePlateNumber }, new { Id = newVehicle.LicensePlateNumber, newVehicle });
    }
}
