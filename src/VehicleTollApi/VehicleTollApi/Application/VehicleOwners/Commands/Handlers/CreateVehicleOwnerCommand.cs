using MediatR;

namespace VehicleTollApi.Application.VehicleOwners.Commands.Handlers;

public record CreateVehicleOwnerCommand(string FirstName, string LastName) : IRequest<CreateVehicleOwnerDto>;
