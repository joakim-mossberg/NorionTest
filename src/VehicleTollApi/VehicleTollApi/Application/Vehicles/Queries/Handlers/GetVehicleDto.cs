
using VehicleTollApi.Shared.Enums;

namespace VehicleTollApi.Application.Vehicles.Queries.Handlers;

public record GetVehicleDto(Guid Id, Guid OwnerId, string LicensePlateNumber, VehicleKind VehicleKind);