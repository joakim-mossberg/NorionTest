using VehicleTollApi.Infrastructure.Persistence.RepositoryInterfaces;

namespace VehicleTollApi.Infrastructure.Persistence;

public class IRepositoryWrapper
{
    IVehicleOwnerRepository? VehicleOwner { get; }
    IVehicleRepository? Vehicle { get; }
}
