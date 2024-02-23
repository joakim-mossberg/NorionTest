using MediatR;
using Microsoft.EntityFrameworkCore;
using VehicleTollApi.Infrastructure.Persistence;

namespace VehicleTollApi.Application.VehicleOwners.Queries.Handlers;

public class GetAllVehicleOwnersHandler : IRequestHandler<GetAllVehicleOwnersQuery, IEnumerable<GetVehicleOwnerDto>>
{
    private IRepositoryWrapper _repositoryWrapper;

    public GetAllVehicleOwnersHandler(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<IEnumerable<GetVehicleOwnerDto>> Handle(GetAllVehicleOwnersQuery request, CancellationToken cancellationToken)
    {
        var result = await _repositoryWrapper.Vehicle.FindAll()
                .ToListAsync(cancellationToken: cancellationToken);

        return result.Select(vehicle => new GetVehicleOwnerDto()).ToList();
    }
}
