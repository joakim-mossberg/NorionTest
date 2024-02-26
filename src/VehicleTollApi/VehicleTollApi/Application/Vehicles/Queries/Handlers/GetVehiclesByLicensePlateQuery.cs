using MediatR;
using VehicleTollApi.Shared;

namespace VehicleTollApi.Application.Vehicles.Queries.Handlers;

public record GetVehiclesByLicensePlateQuery(string LicensePlateNumber) : IRequest<Response<GetVehicleDto>>;