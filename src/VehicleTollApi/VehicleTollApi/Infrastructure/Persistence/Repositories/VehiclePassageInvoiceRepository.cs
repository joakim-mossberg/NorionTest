using VehicleTollApi.Infrastructure.Persistence.Data;
using VehicleTollApi.Infrastructure.Persistence.Models;
using VehicleTollApi.Infrastructure.Persistence.RepositoryInterfaces;

namespace VehicleTollApi.Infrastructure.Persistence.Repositories;

public class VehiclePassageInvoiceRepository : RepositoryBase<VehiclePassageInvoice>, IVehiclePassageInvoiceRepository
{
    public VehiclePassageInvoiceRepository(VehicleTollContext repositoryContext) 
        : base(repositoryContext) { }
}
