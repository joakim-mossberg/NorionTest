using System.Linq.Expressions;
using VehicleTollApi.Infrastructure.Persistence.Models;


namespace VehicleTollApi.Infrastructure.Persistence.RepositoryInterfaces;

public interface IVehiclePassageRepository : IRepositoryBase<VehiclePassage> 
{
    void ExecuteUpdatePassages(Expression<Func<VehiclePassage, bool>> predicate, Guid invoiceId);
}
