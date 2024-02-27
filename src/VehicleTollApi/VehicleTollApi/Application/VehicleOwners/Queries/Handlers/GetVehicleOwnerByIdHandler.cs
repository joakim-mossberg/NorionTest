using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VehicleTollApi.Infrastructure.Persistence;
using VehicleTollApi.Shared;
using VehicleTollApi.Application.VehicleOwners.Mappings;

namespace VehicleTollApi.Application.VehicleOwners.Queries.Handlers;

public class GetVehiclePassageByIdHandler : IRequestHandler<GetVehicleOwnerByIdQuery, Response<GetVehicleOwnerDto>>
{
    private IRepositoryWrapper _repositoryWrapper;
    private IValidator<GetVehicleOwnerByIdQuery> _validator;

    public GetVehiclePassageByIdHandler(IRepositoryWrapper repositoryWrapper,
        IValidator<GetVehicleOwnerByIdQuery> validator)
    {
        _repositoryWrapper = repositoryWrapper;
        _validator = validator;
    }

    public async Task<Response<GetVehicleOwnerDto>> Handle(GetVehicleOwnerByIdQuery request, CancellationToken cancellationToken)
    {
        var validateResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validateResult.IsValid)
        {
            return new Response<GetVehicleOwnerDto>(null!, validateResult.Errors);
        }

        var owner = await _repositoryWrapper.VehicleOwner
            .FindByCondition(vo => vo.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
        return new Response<GetVehicleOwnerDto>(owner!.AsDto());
    }
}
