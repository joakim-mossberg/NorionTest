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
}
