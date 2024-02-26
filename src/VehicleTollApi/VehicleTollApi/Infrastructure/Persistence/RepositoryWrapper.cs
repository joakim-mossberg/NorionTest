using VehicleTollApi.Infrastructure.Persistence.Data;
using VehicleTollApi.Infrastructure.Persistence.Repositories;
using VehicleTollApi.Infrastructure.Persistence.RepositoryInterfaces;

namespace VehicleTollApi.Infrastructure.Persistence;

public class RepositoryWrapper : IRepositoryWrapper
{
    private VehicleTollContext _repoContext;
    private IVehicleOwnerRepository? _vehicleOwner;
    private IVehicleRepository? _vehicle;
    private IVehiclePassageRepository? _vehiclePassage;

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

    public IVehiclePassageRepository VehiclePassage
    {
        get
        {
            if (_vehiclePassage == null)
            {
                _vehiclePassage = new VehiclePassageRepository(_repoContext);
            }
            return _vehiclePassage;
        }
    }

    public RepositoryWrapper(VehicleTollContext repositoryContext)
    {
        _repoContext = repositoryContext;
    }

    public void Save()
    {
        _repoContext.SaveChanges();
    }
}
