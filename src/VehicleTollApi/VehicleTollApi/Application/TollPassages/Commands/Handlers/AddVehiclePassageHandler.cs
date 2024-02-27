using FluentValidation;
using FluentValidation.Results;
using MediatR;
using VehicleTollApi.Application.TollPassages.Mappings;
using VehicleTollApi.Infrastructure.Persistence;
using VehicleTollApi.Shared;

namespace VehicleTollApi.Application.TollPassages.Commands.Handlers;

public class AddVehiclePassageHandler : IRequestHandler<AddVehiclePassageCommand, Response<AddVehiclePassageDto>>
{
    private IRepositoryWrapper _repositoryWrapper;
    private IValidator<AddVehiclePassageCommand> _validator;

    public AddVehiclePassageHandler(IRepositoryWrapper repositoryWrapper,
        IValidator<AddVehiclePassageCommand> validator)
    {
        _repositoryWrapper = repositoryWrapper;
        _validator = validator;
    }

    public async Task<Response<AddVehiclePassageDto>> Handle(AddVehiclePassageCommand request, CancellationToken cancellationToken)
    {
        var validateResult = await _validator.ValidateAsync(request, cancellationToken);
        if(!validateResult.IsValid)
        {
            return new Response<AddVehiclePassageDto>(null!, validateResult.Errors);
        }

        var newVehiclePassage = request.AsModel();
        _repositoryWrapper.VehiclePassage.Create(newVehiclePassage);

        return new Response<AddVehiclePassageDto>(newVehiclePassage.AsDto());
    }
}
