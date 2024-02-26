using MediatR;
using Microsoft.EntityFrameworkCore;
using VehicleTollApi.Application.Vehicles.Mappings;
using VehicleTollApi.Infrastructure.Persistence;
using VehicleTollApi.Shared;

namespace VehicleTollApi.Application.Vehicles.Queries.Handlers;

public class GetVehicleByLicensePlateNumberHandler : IRequestHandler<GetVehiclesByLicensePlateQuery, Response<GetVehicleDto>>
{
    private IRepositoryWrapper _repositoryWrapper;

    public GetVehicleByLicensePlateNumberHandler(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<Response<GetVehicleDto>> Handle(GetVehiclesByLicensePlateQuery request, CancellationToken cancellationToken)
    {
        var result = await _repositoryWrapper.Vehicle
            .FindByCondition(vehicle => vehicle.LicensePlateNumber == request.LicensePlateNumber)
            .FirstOrDefaultAsync(cancellationToken);

        return new Response<GetVehicleDto>(result!.AsDto()!);
    }
}
