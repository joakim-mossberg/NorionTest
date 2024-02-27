using MediatR;
using VehicleTollApi.Shared;

namespace VehicleTollApi.Application.VehiclePassageInvoices.Queries.Handlers;

public record GetAllVehiclePassageInvoicesQuery() : IRequest<Response<IEnumerable<GetVehiclePassageInvoiceDto>>>;
