using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleTollApi.Application.VehicleOwners.Commands.Handlers;
using VehicleTollApi.Application.VehicleOwners.Queries.Handlers;
using VehicleTollApi.WebApi.Models;

namespace VehicleTollApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleOwnersController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehicleOwnersController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VehicleOwnerDTO>>> GetAllVehicleOwners(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllVehicleOwnersQuery(), cancellationToken);
        return Ok(result);
    }

    //[HttpGet("id")]
    //public async Task<ActionResult<VehicleOwnerDTO>> GetVehicleOwnerById(Guid id, CancellationToken cancellationToken)
    //{
    //    var result = await _mediator.Send(new GetVehicleByOwnerIdQuery(id), cancellationToken);
    //    return Ok(result);
    //}

    [HttpPost("newowner")]
    public async Task<IActionResult> CreateVehicleOwner([FromBody]VehicleOwnerDTO vehicleOwner, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CreateVehicleOwnerCommand(vehicleOwner.FirstName, vehicleOwner.LastName), cancellationToken);
        return Ok(result);
    }
}
