using VehicleTollApi.Infrastructure.Persistence.RepositoryInterfaces;

namespace VehicleTollApi.Infrastructure.Persistence;

public interface IRepositoryWrapper
{
    IVehicleOwnerRepository VehicleOwner { get; }
    IVehicleRepository Vehicle { get; }
    IVehiclePassageRepository VehiclePassage { get; }
}
