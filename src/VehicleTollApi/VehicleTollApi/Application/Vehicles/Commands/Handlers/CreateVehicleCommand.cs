using MediatR;
using VehicleTollApi.WebApi.Models;

namespace VehicleTollApi.Application.Vehicles.Commands.Handlers;

public record CreateVehicleCommand(Guid ownerId, string LicencePlateNumber, VehicleKind VehicleKind) : IRequest<CreateVehicleDto>;
