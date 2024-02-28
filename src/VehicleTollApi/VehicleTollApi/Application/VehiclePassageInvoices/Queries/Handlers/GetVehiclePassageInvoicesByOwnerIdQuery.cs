using MediatR;
using VehicleTollApi.Shared;

namespace VehicleTollApi.Application.VehiclePassageInvoices.Queries.Handlers;

public record GetVehiclePassageInvoicesByOwnerIdQuery(Guid OwnerId) : IRequest<Response<IEnumerable<GetVehiclePassageInvoiceDto>>>;
