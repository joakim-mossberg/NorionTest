using MediatR;
using VehicleTollApi.Shared;

namespace VehicleTollApi.Application.TollPassages.Commands.Handlers;

public record AddVehiclePassageCommand(string LicensePlateNumber) : IRequest<Response<AddVehiclePassageDto>>;
