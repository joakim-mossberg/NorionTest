using MediatR;
using VehicleTollApi.Infrastructure.Persistence;
using VehicleTollApi.Shared;

namespace VehicleTollApi.Application.VehicleOwners.Commands.Handlers;

public class CreateVehicleOwnerHandler : IRequestHandler<CreateVehicleOwnerCommand, Response<CreateVehicleOwnerDto>>
{
    private IRepositoryWrapper _repositoryWrapper;

    public CreateVehicleOwnerHandler(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<Response<CreateVehicleOwnerDto>> Handle(CreateVehicleOwnerCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
