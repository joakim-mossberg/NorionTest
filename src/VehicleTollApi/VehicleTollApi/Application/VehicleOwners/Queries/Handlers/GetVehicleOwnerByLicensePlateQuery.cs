using MediatR;
using VehicleTollApi.Shared;

namespace VehicleTollApi.Application.VehicleOwners.Queries.Handlers;

public record GetVehicleOwnerByLicensePlateQuery(string LicensePlateNumber) : IRequest<Response<GetVehicleOwnerDto>>;
