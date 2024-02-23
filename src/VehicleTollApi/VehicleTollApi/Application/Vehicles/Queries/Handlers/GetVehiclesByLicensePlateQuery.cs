using MediatR;

namespace VehicleTollApi.Application.Vehicles.Queries.Handlers;

public record GetVehiclesByLicensePlateQuery(string LicensePlateNumber) : IRequest<GetVehicleDto>;