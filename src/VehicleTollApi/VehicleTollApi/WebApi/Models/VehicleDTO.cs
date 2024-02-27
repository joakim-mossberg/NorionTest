using VehicleTollApi.Shared.Enums;

namespace VehicleTollApi.WebApi.Models;


public record VehicleDTO(Guid Owner, string LicensePlate, VehicleKind VehicleKind);
