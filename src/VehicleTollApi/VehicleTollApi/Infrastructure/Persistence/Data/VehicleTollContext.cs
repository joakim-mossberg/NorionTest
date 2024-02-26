using Microsoft.EntityFrameworkCore;
using VehicleTollApi.Infrastructure.Persistence.Models;

namespace VehicleTollApi.Infrastructure.Persistence.Data;

public class VehicleTollContext : DbContext
{
    public DbSet<VehicleOwner> VehicleOwners { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehiclePassage> VehiclePassages { get; set; }

    protected readonly IConfiguration Configuration;

    public VehicleTollContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // connect to sqlite database
        options.UseSqlite(Configuration.GetConnectionString("VehicleTollSystem"));

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.RemovePluralizingTableNameConvention();
        base.OnModelCreating(modelBuilder);
    }
}
