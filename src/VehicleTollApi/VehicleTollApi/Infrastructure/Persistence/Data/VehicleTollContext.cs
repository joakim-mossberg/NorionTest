using Microsoft.EntityFrameworkCore;
using VehicleTollApi.Infrastructure.Persistence.Models;

namespace VehicleTollApi.Infrastructure.Persistence.Data;

public class VehicleTollContext : DbContext
{
    public DbSet<VehicleOwner> VehicleOwners { get; set; } = default!;
    public DbSet<Vehicle> Vehicles { get; set; } = default!;
    public DbSet<VehiclePassage> VehiclePassages { get; set; } = default!;
    public DbSet<VehiclePassageInvoice> VehiclePassageInvoices { get; set; } = default!;

    protected readonly IConfiguration Configuration = default!;

    public VehicleTollContext() { }

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
