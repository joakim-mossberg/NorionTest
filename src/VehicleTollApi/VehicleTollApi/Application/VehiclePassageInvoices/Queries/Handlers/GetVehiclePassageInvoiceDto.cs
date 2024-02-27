namespace VehicleTollApi.Application.VehiclePassageInvoices.Queries.Handlers;

public record GetVehiclePassageInvoiceDto(Guid Id, decimal? Amount, DateTimeOffset InvoiceDateTime);