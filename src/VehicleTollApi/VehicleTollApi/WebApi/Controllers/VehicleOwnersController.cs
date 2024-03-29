﻿using MediatR;
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
    public async Task<IActionResult> GetAllVehicleOwners(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllVehicleOwnersQuery(), cancellationToken);
        if (!result.IsValidResponse)
        {
            return BadRequest(result.Errors);
        }
        return Ok(result.Result);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetVehicleOwner(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetVehicleOwnerByIdQuery(id), cancellationToken);
        if (!result.IsValidResponse)
        {
            return BadRequest(result.Errors);
        }
        return Ok(result.Result);
    }

    [HttpPost("newowner")]
    public async Task<ActionResult<VehicleOwnerDTO>> CreateVehicleOwner([FromBody]NewVehicleOwnerDTO vehicleOwner, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new CreateVehicleOwnerCommand(vehicleOwner.FirstName, vehicleOwner.LastName), cancellationToken);
        if (!result.IsValidResponse)
        {
            return BadRequest(result.Errors);
        }
        var newOwner = result.Result;
        return CreatedAtAction(nameof(GetVehicleOwner), new { id = newOwner.Id }, new { Id = newOwner.Id, newOwner });
    }
}
