using FluentValidation;
using VehicleTollApi.Application.VehicleOwners.Queries.Handlers;

namespace VehicleTollApi.Application.VehicleOwners.Commands.Validators;

public sealed class GetVehicleOwnerByIdQueryValidator : AbstractValidator<GetVehicleOwnerByIdQuery>
{
    public GetVehicleOwnerByIdQueryValidator()
    {
        RuleFor(vp => vp.Id).NotEmpty();
    }
}
