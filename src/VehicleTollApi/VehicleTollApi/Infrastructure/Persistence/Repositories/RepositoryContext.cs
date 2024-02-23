using Microsoft.EntityFrameworkCore;
using VehicleTollApi.Infrastructure.Persistence.Models;

namespace VehicleTollApi.Infrastructure.Persistence.Repositories;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options)
    : base(options)
    {
    }

    public DbSet<VehicleOwner> VehicleOwners { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
}
