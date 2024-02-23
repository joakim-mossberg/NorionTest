using VehicleTollApi.WebApi.Models;

namespace VehicleTollApi.Application.Vehicles.Commands.Handlers;

public record GetVehiclesByLicensePlateCommand(Guid ownerId, string LicencePlateNumber, VehicleKind VehicleKind);
