using FluentValidation;
using VehicleTollApi.Application.VehicleOwners.Queries.Handlers;

namespace VehicleTollApi.Application.VehicleOwners.Commands.Validators;

public sealed class GetAllVehicleOwnersQueryValidator : AbstractValidator<GetAllVehicleOwnersQuery>
{
    public GetAllVehicleOwnersQueryValidator()
    {
    }
}
