using MediatR;

namespace VehicleTollApi.Application.Vehicles.Queries.Handlers;

public record GetAllVehiclesQuery() : IRequest<IEnumerable<GetVehicleDto>>;