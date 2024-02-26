using VehicleTollApi.Infrastructure.Persistence.Data;
using VehicleTollApi.Infrastructure.Persistence.Models;
using VehicleTollApi.Infrastructure.Persistence.RepositoryInterfaces;

namespace VehicleTollApi.Infrastructure.Persistence.Repositories;

public class VehiclePassageRepository : RepositoryBase<VehiclePassage>, IVehiclePassageRepository
{
    public VehiclePassageRepository(VehicleTollContext repositoryContext) 
        : base(repositoryContext) { }
}
