using VehicleTollApi.Infrastructure.Persistence.Models;
using VehicleTollApi.Infrastructure.Persistence.RepositoryInterfaces;
using System.Linq.Expressions;

namespace VehicleTollApi.Infrastructure.Persistence.Repositories;

public class VehicleRepository : RepositoryBase<Vehicle>, IVehicleRepository
{
    public VehicleRepository(RepositoryContext repositoryContext)
        : base(repositoryContext) { }

}
