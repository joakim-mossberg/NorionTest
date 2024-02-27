using MediatR;
using VehicleTollApi.Shared;

namespace VehicleTollApi.Application.TollPassages.Commands.Handlers;

public record AddVehiclePassageCommand(string LicensePlateNumber, DateTimeOffset PassageDateTime) : IRequest<Response<AddVehiclePassageDto>>;
