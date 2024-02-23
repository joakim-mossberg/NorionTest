using MediatR;
using Microsoft.AspNetCore.Mvc;
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

    [HttpGet("licensePlateNumber")]
    public async Task<ActionResult<VehicleDTO>> GetVehicleByLicensePlate(string licensePlateNumber)
    {
        var result = await _mediator.Send(new GetVehiclesByLicensePlateQuery(licensePlateNumber));
        return Ok(result);
    }

    [HttpPost("newvehicle")]
    public async Task<IActionResult> CreateVehicle(Guid owner, string licensePlate, VehicleKind vehicleKind)
    {
        var result = await _mediator.Send(new CreateVehicleCommand(owner, licensePlate, vehicleKind));
        var newVehicle = new VehicleDTO(owner, licensePlate, vehicleKind);
        return CreatedAtAction(nameof(CreateVehicle), new { licensePlateNumber = newVehicle.LicensePlate }, new { Id = newVehicle.LicensePlate, newVehicle });
    }
}
