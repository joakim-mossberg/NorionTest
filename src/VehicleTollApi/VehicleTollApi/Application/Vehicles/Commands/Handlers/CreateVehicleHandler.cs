using FluentValidation;
using MediatR;
using VehicleTollApi.Application.Vehicles.Mappings;
using VehicleTollApi.Infrastructure.Persistence;
using VehicleTollApi.Shared;

namespace VehicleTollApi.Application.Vehicles.Commands.Handlers;

public class CreateVehicleHandler : IRequestHandler<CreateVehicleCommand, Response<CreateVehicleDto>>
{
    private IRepositoryWrapper _repositoryWrapper;
    private IValidator<CreateVehicleCommand> _validator;

    public CreateVehicleHandler(IRepositoryWrapper repositoryWrapper,
        IValidator<CreateVehicleCommand> validator)
    {
        _repositoryWrapper = repositoryWrapper;
        _validator = validator;
    }

    public async Task<Response<CreateVehicleDto>> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var validateResult = await _validator.ValidateAsync(request, cancellationToken);
        if(!validateResult.IsValid)
        {
            return new Response<CreateVehicleDto>(null!, validateResult.Errors);
        }

        var vehicle = request.AsModel();
        _repositoryWrapper.Vehicle.Create(vehicle);
        _repositoryWrapper.Save();
        return new Response<CreateVehicleDto>(vehicle.AsNewDto(request.OwnerId));
    }
}
