using Microsoft.EntityFrameworkCore;
using VehicleTollApi.Infrastructure.Persistence.Models;

namespace VehicleTollApi.Infrastructure.Persistence.Repositories;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options)
    : base(options)
    {
    }

    DbSet<VehicleOwner> VehicleOwners { get; set; }
    DbSet<Vehicle> Vehicles { get; set; }
}
