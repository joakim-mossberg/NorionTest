using MediatR;
using VehicleTollApi.Shared;

namespace VehicleTollApi.Application.VehicleOwners.Queries.Handlers;

public record GetVehicleOwnerByIdQuery(Guid Id) : IRequest<Response<GetVehicleOwnerDto>>;
