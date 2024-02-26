using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VehicleTollApi.Application.VehicleOwners.Mappings;
using VehicleTollApi.Infrastructure.Persistence;
using VehicleTollApi.Shared;

namespace VehicleTollApi.Application.VehicleOwners.Queries.Handlers;

public class GetAllVehicleOwnersHandler : IRequestHandler<GetAllVehicleOwnersQuery, Response<IEnumerable<GetVehicleOwnerDto>>>
{
    private IRepositoryWrapper _repositoryWrapper;
    private IValidator<GetAllVehicleOwnersQuery> _validator;

    public GetAllVehicleOwnersHandler(IRepositoryWrapper repositoryWrapper,
        IValidator<GetAllVehicleOwnersQuery> validator)
    {
        _repositoryWrapper = repositoryWrapper;
        _validator = validator;
    }

    public async Task<Response<IEnumerable<GetVehicleOwnerDto>>> Handle(GetAllVehicleOwnersQuery request, CancellationToken cancellationToken)
    {
        var validateResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validateResult.IsValid)
        {
            return new Response<IEnumerable<GetVehicleOwnerDto>>(null!, validateResult.Errors);
        }

        var result = await _repositoryWrapper.VehicleOwner.FindAll()
                .ToListAsync(cancellationToken);

        return new Response<IEnumerable<GetVehicleOwnerDto>>(result.Select(owner => owner.AsDto()).ToList());
    }
}
