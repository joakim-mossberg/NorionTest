namespace VehicleTollApi.Application.VehiclePassageInvoices.Commands.Handlers;

public record CreatedVehiclePassageInvoiceDto(Guid Id, decimal? Amount, DateTimeOffset InvoiceDateTime, Guid? VehicleOwnerId);