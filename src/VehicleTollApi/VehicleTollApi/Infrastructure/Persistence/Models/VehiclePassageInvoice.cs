namespace VehicleTollApi.Infrastructure.Persistence.Models;

public class VehiclePassageInvoice
{
    public Guid Id { get; set; }
    public ICollection<VehiclePassage>? VehiclePassages { get; }
}