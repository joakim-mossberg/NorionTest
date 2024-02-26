using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VehicleTollApi.Infrastructure.Persistence;
using VehicleTollApi.Shared;
using VehicleTollApi.Application.VehicleOwners.Mappings;

namespace VehicleTollApi.Application.VehicleOwners.Queries.Handlers;

public class GetVehicleOwnerByLicensePlateHandler : IRequestHandler<GetVehicleOwnerByLicensePlateQuery, Response<GetVehicleOwnerDto>>
{
    private IRepositoryWrapper _repositoryWrapper;
    private IValidator<GetVehicleOwnerByLicensePlateQuery> _validator;

    public GetVehicleOwnerByLicensePlateHandler(IRepositoryWrapper repositoryWrapper,
        IValidator<GetVehicleOwnerByLicensePlateQuery> validator)
    {
        _repositoryWrapper = repositoryWrapper;
        _validator = validator;
    }

    public async Task<Response<GetVehicleOwnerDto>> Handle(GetVehicleOwnerByLicensePlateQuery request, CancellationToken cancellationToken)
    {
        var validateResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validateResult.IsValid)
        {
            return new Response<GetVehicleOwnerDto>(null!, validateResult.Errors);
        }

        var owner = await _repositoryWrapper.VehicleOwner
            .FindByCondition(vo => vo.Vehicles!.Any(v => v.LicensePlateNumber == request.LicensePlateNumber))
            .FirstOrDefaultAsync(cancellationToken);
        return new Response<GetVehicleOwnerDto>(owner!.AsDto());
    }
}
