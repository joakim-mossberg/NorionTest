using MediatR;

namespace VehicleTollApi.Application.TollPassages.Commands.Handlers;

public record AddVehiclePassageCommand(string LicensePlateNumber) : IRequest<AddVehiclePassageDto>;
