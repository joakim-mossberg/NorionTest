using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using VehicleTollApi.Infrastructure.Persistence;
using VehicleTollApi.Shared;
using VehicleTollApi.Application.TollPassages.Mappings;

namespace VehicleTollApi.Application.TollPassages.Queries.Handlers;

public class GetVehiclePassageByIdHandler : IRequestHandler<GetVehiclePassageByIdQuery, Response<GetVehiclePassageDto>>
{
    private IRepositoryWrapper _repositoryWrapper;
    private IValidator<GetVehiclePassageByIdQuery> _validator;

    public GetVehiclePassageByIdHandler(IRepositoryWrapper repositoryWrapper,
        IValidator<GetVehiclePassageByIdQuery> validator)
    {
        _repositoryWrapper = repositoryWrapper;
        _validator = validator;
    }

    public async Task<Response<GetVehiclePassageDto>> Handle(GetVehiclePassageByIdQuery request, CancellationToken cancellationToken)
    {
        var validateResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validateResult.IsValid)
        {
            return new Response<GetVehiclePassageDto>(null!, validateResult.Errors);
        }

        var passage = await _repositoryWrapper.VehiclePassage
            .FindByCondition(vo => vo.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken);
        return new Response<GetVehiclePassageDto>(passage!.AsDto());
    }
}
