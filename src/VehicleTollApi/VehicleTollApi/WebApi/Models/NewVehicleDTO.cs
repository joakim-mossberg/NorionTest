using VehicleTollApi.Shared.Enums;

namespace VehicleTollApi.WebApi.Models;


public record NewVehicleDTO(Guid OwnerId, string LicensePlate, VehicleKind VehicleKind);
