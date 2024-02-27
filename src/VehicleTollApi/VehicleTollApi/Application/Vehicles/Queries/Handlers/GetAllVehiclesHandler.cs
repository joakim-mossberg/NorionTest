using MediatR;
using Microsoft.EntityFrameworkCore;
using VehicleTollApi.Infrastructure.Persistence;
using VehicleTollApi.Shared;
using VehicleTollApi.WebApi.Models;

namespace VehicleTollApi.Application.Vehicles.Queries.Handlers;

public class GetAllVehiclesHandler : IRequestHandler<GetAllVehiclesQuery, Response<IEnumerable<GetVehicleDto>>>
{
    private IRepositoryWrapper _repositoryWrapper;

    public GetAllVehiclesHandler(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<Response<IEnumerable<GetVehicleDto>>> Handle(GetAllVehiclesQuery request,
                                                                   CancellationToken cancellationToken)
    {
        var result = await _repositoryWrapper.Vehicle.FindAll()
            .ToListAsync(cancellationToken);

        return new Response<IEnumerable<GetVehicleDto>>(
            result.Select(vehicle => new GetVehicleDto(vehicle.Id,
                                                        vehicle.VehicleOwnerId,
                                                        vehicle.LicensePlateNumber,
                                                        vehicle.VehicleKind))
            .ToList());
    }
}
