using MediatR;
using VehicleTollApi.Shared;
using VehicleTollApi.Shared.Enums;

namespace VehicleTollApi.Application.VehiclePassageInvoices.Commands.Handlers;

public record VehiclePassage(Guid Id, DateTimeOffset PassageDateTime);

public record CreateVehiclePassageInvoiceCommand(Guid OwnerId, VehicleKind VehicleKind, IEnumerable<VehiclePassage> Passages) 
    : IRequest<Response<CreatedVehiclePassageInvoiceDto>>;
