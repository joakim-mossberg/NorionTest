using FluentValidation;
using VehicleTollApi.Application.TollPassages.Commands.Handlers;

namespace VehicleTollApi.Application.TollPassages.Commands.Validators;

public sealed class CreateVehicleOwnerCommandValidator : AbstractValidator<AddVehiclePassageCommand>
{
    public CreateVehicleOwnerCommandValidator()
    {
        RuleFor(vp => vp.LicensePlateNumber).MinimumLength(6).MaximumLength(10);
        RuleFor(vp => vp.PassageDateTime).GreaterThan(DateTimeOffset.MinValue);
    }
}
