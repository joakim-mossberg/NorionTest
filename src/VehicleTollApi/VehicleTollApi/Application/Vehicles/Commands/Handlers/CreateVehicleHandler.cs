using MediatR;
using VehicleTollApi.Infrastructure.Persistence;

namespace VehicleTollApi.Application.Vehicles.Commands.Handlers;

public class CreateVehicleHandler : IRequestHandler<CreateVehicleCommand, CreateVehicleDto>
{
    private IRepositoryWrapper _repositoryWrapper;

    public CreateVehicleHandler(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<CreateVehicleDto> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
