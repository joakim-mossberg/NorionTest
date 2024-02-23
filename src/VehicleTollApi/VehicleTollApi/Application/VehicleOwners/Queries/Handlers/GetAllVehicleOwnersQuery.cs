using MediatR;

namespace VehicleTollApi.Application.VehicleOwners.Queries.Handlers;

public record GetAllVehicleOwnersQuery() : IRequest<IEnumerable<GetVehicleOwnerDto>>;
