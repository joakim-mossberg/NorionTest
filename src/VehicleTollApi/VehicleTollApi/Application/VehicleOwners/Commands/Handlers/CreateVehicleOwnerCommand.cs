using MediatR;
using VehicleTollApi.Shared;

namespace VehicleTollApi.Application.VehicleOwners.Commands.Handlers;

public record CreateVehicleOwnerCommand(string FirstName, string LastName) : IRequest<Response<CreateVehicleOwnerDto>>;
