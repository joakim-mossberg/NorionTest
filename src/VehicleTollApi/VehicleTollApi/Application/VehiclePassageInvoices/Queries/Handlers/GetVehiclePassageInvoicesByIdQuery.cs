using MediatR;
using VehicleTollApi.Shared;

namespace VehicleTollApi.Application.VehiclePassageInvoices.Queries.Handlers;

public record GetVehiclePassageInvoicesByIdQuery(Guid Id) : IRequest<Response<GetVehiclePassageInvoiceDto>>;