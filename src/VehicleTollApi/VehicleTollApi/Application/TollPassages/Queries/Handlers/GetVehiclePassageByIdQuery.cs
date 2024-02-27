using MediatR;
using VehicleTollApi.Shared;

namespace VehicleTollApi.Application.TollPassages.Queries.Handlers;

public record GetVehiclePassageByIdQuery(Guid Id) : IRequest<Response<GetVehiclePassageDto>>;
