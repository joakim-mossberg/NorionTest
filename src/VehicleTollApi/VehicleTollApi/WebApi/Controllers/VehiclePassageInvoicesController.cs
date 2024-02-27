using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace VehicleTollApi.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehiclePassageInvoicesController : ControllerBase
{
    private readonly IMediator _mediator;

    public VehiclePassageInvoicesController(IMediator mediator) => _mediator = mediator;

}
