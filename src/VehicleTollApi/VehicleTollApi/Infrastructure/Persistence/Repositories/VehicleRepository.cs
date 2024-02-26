using VehicleTollApi.Infrastructure.Persistence.Models;
using VehicleTollApi.Infrastructure.Persistence.RepositoryInterfaces;
using System.Linq.Expressions;
using VehicleTollApi.Infrastructure.Persistence.Data;

namespace VehicleTollApi.Infrastructure.Persistence.Repositories;

public class VehicleRepository : RepositoryBase<Vehicle>, IVehicleRepository
{
    public VehicleRepository(VehicleTollContext repositoryContext)
        : base(repositoryContext) { }

}
