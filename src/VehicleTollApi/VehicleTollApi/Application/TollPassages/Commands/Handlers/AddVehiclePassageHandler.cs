using MediatR;
using VehicleTollApi.Infrastructure.Persistence;

namespace VehicleTollApi.Application.TollPassages.Commands.Handlers;

public class AddVehiclePassageHandler : IRequestHandler<AddVehiclePassageCommand, AddVehiclePassageDto>
{
    private IRepositoryWrapper _repositoryWrapper;

    public AddVehiclePassageHandler(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }

    public async Task<AddVehiclePassageDto> Handle(AddVehiclePassageCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
