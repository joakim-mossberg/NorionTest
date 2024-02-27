using VehicleTollApi.Application.Vehicles.Commands.Handlers;
using VehicleTollApi.Application.Vehicles.Queries.Handlers;
using VehicleTollApi.Infrastructure.Persistence.Models;

namespace VehicleTollApi.Application.Vehicles.Mappings;

public static class VehicleMappings
{
    public static GetVehicleDto AsDto(this Vehicle vehicle)
    {
        if (vehicle is null)
        {
            return null!;
        }
        return new GetVehicleDto(vehicle.Id, vehicle.VehicleOwnerId, vehicle.LicensePlateNumber!, vehicle.VehicleKind);
    }

    public static CreateVehicleDto AsNewDto(this Vehicle vehicle, Guid ownerId)
    {
        if (vehicle is null)
        {
            return null!;
        }
        return new CreateVehicleDto(vehicle.Id, ownerId, vehicle.LicensePlateNumber!, vehicle.VehicleKind);
    }

    public static Vehicle AsModel(this CreateVehicleCommand vehicleCommand)
    {
        return new Vehicle()
        {
            VehicleOwnerId = vehicleCommand.OwnerId,
            LicensePlateNumber = vehicleCommand.LicencePlateNumber,
            VehicleKind = vehicleCommand.VehicleKind,
        };
    }
}
