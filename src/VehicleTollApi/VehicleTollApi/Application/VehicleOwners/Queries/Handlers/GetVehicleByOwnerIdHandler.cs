using MediatR;
using VehicleTollApi.Infrastructure.Persistence;

namespace VehicleTollApi.Application.VehicleOwners.Queries.Handlers;

public class GetVehicleByOwnerIdHandler : IRequestHandler<GetVehicleByOwnerIdQuery, GetVehicleOwnerDto>
{
    private IRepositoryWrapper _repositoryWrapper;

    public GetVehicleByOwnerIdHandler(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<GetVehicleOwnerDto> Handle(GetVehicleByOwnerIdQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
