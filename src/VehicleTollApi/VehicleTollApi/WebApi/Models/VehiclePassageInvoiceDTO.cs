namespace VehicleTollApi.WebApi.Models;

public record VehiclePassageInvoiceDTO(Guid Id, Guid OwnerId, decimal? Amount, DateTimeOffset InvoiceDateTime);