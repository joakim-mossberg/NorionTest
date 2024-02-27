using MediatR;
using Microsoft.AspNetCore.Mvc;
using VehicleTollApi.Application.VehiclePassageInvoices.Queries.Handlers;

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

}
