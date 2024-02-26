using FluentValidation;
using VehicleTollApi.Application.TollPassages.Commands.Handlers;

namespace VehicleTollApi.Application.TollPassages.Commands.Validators;

public sealed class AddVehiclePassageCommandValidator : AbstractValidator<AddVehiclePassageCommand>
{
    public AddVehiclePassageCommandValidator()
    {
        RuleFor(vp => vp.LicensePlateNumber).MinimumLength(6).MaximumLength(10);
    }
}
