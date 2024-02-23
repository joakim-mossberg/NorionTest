using MediatR;
using Microsoft.EntityFrameworkCore;
using VehicleTollApi.Infrastructure.Persistence;

namespace VehicleTollApi.Application.Vehicles.Queries.Handlers;

public class GetAllVehiclesHandler : IRequestHandler<GetAllVehiclesQuery, IEnumerable<GetVehicleDto>>
{
    private IRepositoryWrapper _repositoryWrapper;

    public GetAllVehiclesHandler(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<IEnumerable<GetVehicleDto>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
    {
        var result = await _repositoryWrapper.Vehicle.FindAll()
            .ToListAsync(cancellationToken: cancellationToken);

        return result.Select(vehicle => new GetVehicleDto()).ToList();
    }
}
