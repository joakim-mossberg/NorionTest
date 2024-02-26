using MediatR;
using VehicleTollApi.Shared;
using VehicleTollApi.WebApi.Models;

namespace VehicleTollApi.Application.Vehicles.Commands.Handlers;

public record CreateVehicleCommand(Guid OwnerId, string LicencePlateNumber, VehicleKind VehicleKind) : IRequest<Response<CreateVehicleDto>>;
