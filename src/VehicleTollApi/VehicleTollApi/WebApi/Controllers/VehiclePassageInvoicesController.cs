using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleTollApi.Application.TollPassages.Queries.Handlers;
using VehicleTollApi.Application.VehiclePassageInvoices.Commands.Handlers;
using VehicleTollApi.Application.VehiclePassageInvoices.Queries.Handlers;
using VehicleTollApi.Application.Vehicles.Queries.Handlers;
using VehicleTollApi.WebApi.Models;

namespace VehicleTollApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehiclePassageInvoicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehiclePassageInvoicesController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAllVehiclePassageInvoices(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllVehiclePassageInvoicesQuery(), cancellationToken);
        if (!result.IsValidResponse)
        {
            return BadRequest(result.Errors);
        }
        return Ok(result.Result);
    }

    [HttpGet("ownerid")]
    public async Task<IActionResult> GetAllVehiclePassageByOwnerIdInvoices(Guid ownerId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetVehiclePassageInvoicesByOwnerIdQuery(ownerId), cancellationToken);
        if (!result.IsValidResponse)
        {
            return BadRequest(result.Errors);
        }
        return Ok(result.Result);
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetVehiclePassageByIdInvoices(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetVehiclePassageInvoicesByIdQuery(id), cancellationToken);
        if (!result.IsValidResponse)
        {
            return BadRequest(result.Errors);
        }
        return Ok(result.Result);
    }

    public async Task<ActionResult<VehiclePassageInvoiceDTO>> CreateVehiclePassageInvoice([FromBody] VehiclePassageInvoice vehiclePassageInvoice,
                                                                                          CancellationToken cancellationToken)
    {
        var vehicleResult = await _mediator.Send(new GetVehiclesByLicensePlateQuery(vehiclePassageInvoice.LicensePlateNumber));
        if (!vehicleResult.IsValidResponse)
        {
            return BadRequest(vehicleResult.Errors);
        }
        var passagesResult = await _mediator.Send(new GetUnInvoicedByLicensePlateNumberQuery(vehiclePassageInvoice.LicensePlateNumber,
                                                                                       vehiclePassageInvoice.UntilDateTime));
        if (!passagesResult.IsValidResponse)
        {
            return BadRequest(passagesResult.Errors);
        }

        var vehicle = vehicleResult.Result;
        var passages = passagesResult.Result;
        var result = await _mediator.Send(
            new CreateVehiclePassageInvoiceCommand(vehicle.OwnerId,
                                                    vehicle.VehicleKind,
                                                    passages.Select(passage => new VehiclePassage(passage.Id,
                                                                                                passage.PassageDateTime)))
            );

        if (!result.IsValidResponse)
        {
            return BadRequest(passagesResult.Errors);
        }

        return CreatedAtAction(nameof(GetVehiclePassageByIdInvoices), new { id = invoice.Id }, new { Id = invoice.Id, invoice });
    }
}
