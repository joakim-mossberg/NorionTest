using System.Reflection.Metadata;
using VehicleTollApi.Shared.Enums;

namespace VehicleTollApi.Application.Vehicles.Commands.Handlers;

public record CreateVehicleDto(Guid Id, Guid OwnerId, string LicensePlateNumber, VehicleKind VehicleKind);
