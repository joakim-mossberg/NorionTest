namespace VehicleTollApi.Infrastructure.Persistence.Models;

public class VehiclePassageInvoice
{
    public Guid Id { get; set; }
    public decimal? Amount { get; set; }
    public DateTimeOffset InvoiceDateTime { get; set; }
    public ICollection<VehiclePassage>? VehiclePassages { get; }
}