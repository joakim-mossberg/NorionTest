using MediatR;
using VehicleTollApi.Infrastructure.Persistence;

namespace VehicleTollApi.Application.VehicleOwners.Commands.Handlers;

public class CreateVehicleOwnerHandler : IRequestHandler<CreateVehicleOwnerCommand, CreateVehicleOwnerDto>
{
    private IRepositoryWrapper _repositoryWrapper;

    public CreateVehicleOwnerHandler(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<CreateVehicleOwnerDto> Handle(CreateVehicleOwnerCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
