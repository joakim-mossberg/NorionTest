using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VehicleTollApi.Infrastructure.Persistence.Data;
using VehicleTollApi.Infrastructure.Persistence.Models;
using VehicleTollApi.Infrastructure.Persistence.RepositoryInterfaces;

namespace VehicleTollApi.Infrastructure.Persistence.Repositories;

public class VehiclePassageRepository : RepositoryBase<VehiclePassage>, IVehiclePassageRepository
{
    public VehiclePassageRepository(VehicleTollContext repositoryContext) 
        : base(repositoryContext) { }

    public void ExecuteUpdatePassages(Expression<Func<VehiclePassage, bool>> predicate, Guid invoiceId)
    {
        RepositoryContext.VehiclePassages
            .Where(predicate)
            .ExecuteUpdate(s => s.SetProperty(e => e.Id, invoiceId));
    }
}
