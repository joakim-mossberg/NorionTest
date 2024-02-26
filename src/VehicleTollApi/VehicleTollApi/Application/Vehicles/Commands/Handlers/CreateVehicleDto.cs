using System.Reflection.Metadata;

namespace VehicleTollApi.Application.Vehicles.Commands.Handlers;

public record CreateVehicleDto(Guid Id, Guid OwnerId, string LicensePlateNumber);
