namespace VehicleTollApi.WebApi.Models;

public record VehiclePassageInvoice(string LicensePlateNumber, DateTimeOffset UntilDateTime);