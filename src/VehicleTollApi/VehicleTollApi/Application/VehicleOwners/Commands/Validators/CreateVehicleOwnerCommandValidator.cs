using FluentValidation;
using VehicleTollApi.Application.TollPassages.Commands.Handlers;
using VehicleTollApi.Application.VehicleOwners.Commands.Handlers;

namespace VehicleTollApi.Application.VehicleOwners.Commands.Validators;

public sealed class CreateVehicleOwnerCommandValidator : AbstractValidator<CreateVehicleOwnerCommand>
{
    public CreateVehicleOwnerCommandValidator()
    {
        RuleFor(vp => vp.FirstName).MinimumLength(1).MaximumLength(50);
        RuleFor(vp => vp.LastName).MinimumLength(1).MaximumLength(50);
    }
}
