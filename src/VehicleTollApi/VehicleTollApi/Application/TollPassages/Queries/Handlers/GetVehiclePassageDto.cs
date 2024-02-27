namespace VehicleTollApi.Application.TollPassages.Queries.Handlers;

public record GetVehiclePassageDto(Guid Id, string LicensePlateNumber, DateTimeOffset PassageDateTime);