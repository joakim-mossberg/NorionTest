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
    public async Task<ActionResult<IEnumerable<VehicleOwnerDTO>>> GetAllVehicleOwners()
    {
        var result = await _mediator.Send(new GetAllVehicleOwnersQuery());
        return Ok(result);
    }

    [HttpGet("id")]
    public async Task<ActionResult<VehicleOwnerDTO>> GetVehicleOwnerById(Guid id)
    {
        var result = await _mediator.Send(new GetVehicleByOwnerIdQuery(id));
        return Ok(result);
    }

    [HttpPost("newowner")]
    public async Task<IActionResult> CreateVehicleOwner(string firstName, string lastName)
    {
        var result = await _mediator.Send(new CreateVehicleOwnerCommand(firstName, lastName));
        return Ok(result);
    }
}
