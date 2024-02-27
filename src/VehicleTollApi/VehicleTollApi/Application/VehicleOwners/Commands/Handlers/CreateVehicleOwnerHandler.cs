using FluentValidation;
using MediatR;
using VehicleTollApi.Infrastructure.Persistence;
using VehicleTollApi.Shared;
using VehicleTollApi.Application.VehicleOwners.Mappings;

namespace VehicleTollApi.Application.VehicleOwners.Commands.Handlers;

public class CreateVehicleOwnerHandler : IRequestHandler<CreateVehicleOwnerCommand, Response<CreateVehicleOwnerDto>>
{
    private IRepositoryWrapper _repositoryWrapper;
    private IValidator<CreateVehicleOwnerCommand> _validator;

    public CreateVehicleOwnerHandler(IRepositoryWrapper repositoryWrapper,
        IValidator<CreateVehicleOwnerCommand> validator)
    {
        _repositoryWrapper = repositoryWrapper;
        _validator = validator;
    }

    public async Task<Response<CreateVehicleOwnerDto>> Handle(CreateVehicleOwnerCommand request, CancellationToken cancellationToken)
    {
        var validateResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validateResult.IsValid)
        {
            return new Response<CreateVehicleOwnerDto>(null!, validateResult.Errors);
        }

        var newVehicleOwner = request.AsModel();
        _repositoryWrapper.VehicleOwner.Create(newVehicleOwner);
        _repositoryWrapper.Save();

        return new Response<CreateVehicleOwnerDto>(newVehicleOwner.AsNewDto());
    }
}
