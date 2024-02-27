using VehicleTollApi.Application.VehicleOwners.Commands.Handlers;
using VehicleTollApi.Application.VehicleOwners.Queries.Handlers;
using VehicleTollApi.Infrastructure.Persistence.Models;

namespace VehicleTollApi.Application.VehicleOwners.Mappings;

public static class VehicleOwnerMappings
{
    public static GetVehicleOwnerDto AsDto(this VehicleOwner vehicleOwner)
    {
        if(vehicleOwner is null)
        {
            return null!;
        }
        return new GetVehicleOwnerDto(vehicleOwner.Id, vehicleOwner.FirstName, vehicleOwner.LastName);
    }

    public static CreateVehicleOwnerDto AsNewDto(this VehicleOwner vehicleOwner)
    {
        if (vehicleOwner is null)
        {
            return null!;
        }
        return new CreateVehicleOwnerDto(vehicleOwner.Id, vehicleOwner.FirstName, vehicleOwner.LastName);
    }

    public static VehicleOwner AsModel(this CreateVehicleOwnerCommand createVehicleOwner)
    {
        if(createVehicleOwner is null)
        {
            return null!;
        }
        return new VehicleOwner()
        {
            FirstName = createVehicleOwner.FirstName,
            LastName = createVehicleOwner.LastName,
        };
    }
}
