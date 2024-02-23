namespace VehicleTollApi.WebApi.Models;

public enum VehicleKind
{
    Motorbike = 0,
    Tractor = 1,
    Emergency = 2,
    Diplomat = 3,
    Foreign = 4,
    Military = 5,
    Car = 6,
}

public record VehicleDTO(Guid Owner, string LicensePlate, VehicleKind VehicleKind);
