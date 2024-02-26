using MediatR;
using VehicleTollApi.Shared;

namespace VehicleTollApi.Application.Vehicles.Queries.Handlers;

public record GetAllVehiclesQuery() : IRequest<Response<IEnumerable<GetVehicleDto>>>;