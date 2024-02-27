using VehicleTollApi.Shared.Enums;

namespace VehicleTollApi.WebApi.Models;


public record VehicleDTO(Guid OwnerId, string LicensePlate, VehicleKind VehicleKind);
