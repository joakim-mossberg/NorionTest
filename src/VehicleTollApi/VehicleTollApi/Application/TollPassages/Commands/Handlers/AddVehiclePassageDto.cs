namespace VehicleTollApi.Application.TollPassages.Commands.Handlers;

public record AddVehiclePassageDto(string LicensePlateNumber, DateTimeOffset passageTime);