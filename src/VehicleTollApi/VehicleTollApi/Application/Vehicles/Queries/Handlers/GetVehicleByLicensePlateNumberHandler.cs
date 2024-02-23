using MediatR;
using VehicleTollApi.Infrastructure.Persistence;

namespace VehicleTollApi.Application.Vehicles.Queries.Handlers;

public class GetVehicleByLicensePlateNumberHandler : IRequestHandler<GetVehiclesByLicensePlateQuery, GetVehicleDto>
{
    private IRepositoryWrapper _repositoryWrapper;

    public GetVehicleByLicensePlateNumberHandler(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<GetVehicleDto> Handle(GetVehiclesByLicensePlateQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
