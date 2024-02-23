using VehicleTollApi.Infrastructure.Persistence.Repositories;
using VehicleTollApi.Infrastructure.Persistence.RepositoryInterfaces;

namespace VehicleTollApi.Infrastructure.Persistence;

public class RepositoryWrapper : IRepositoryWrapper
{
    private RepositoryContext _repoContext;
    private IVehicleOwnerRepository? _vehicleOwner;
    private IVehicleRepository? _vehicle;

    public IVehicleOwnerRepository VehicleOwner
    {
        get
        {
            if (_vehicleOwner == null)
            {
                _vehicleOwner = new VehicleOwnerRepository(_repoContext);
            }
            return _vehicleOwner;
        }
    }

    public IVehicleRepository Vehicle
    {
        get
        {
            if (_vehicle == null)
            {
                _vehicle = new VehicleRepository(_repoContext);
            }
            return _vehicle;
        }
    }

    public RepositoryWrapper(RepositoryContext repositoryContext)
    {
        _repoContext = repositoryContext;
    }

    public void Save()
    {
        _repoContext.SaveChanges();
    }
}
