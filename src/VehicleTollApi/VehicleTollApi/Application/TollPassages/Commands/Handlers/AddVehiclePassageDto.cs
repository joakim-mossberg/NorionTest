namespace VehicleTollApi.Application.TollPassages.Commands.Handlers;

public record AddVehiclePassageDto(Guid Id, string LicensePlateNumber, DateTimeOffset passageTime);