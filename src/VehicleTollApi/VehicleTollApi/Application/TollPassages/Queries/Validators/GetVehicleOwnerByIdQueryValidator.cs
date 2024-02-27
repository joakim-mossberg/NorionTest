using FluentValidation;
using VehicleTollApi.Application.TollPassages.Queries.Handlers;

namespace VehicleTollApi.Application.TollPassages.Commands.Validators;

public sealed class GetVehiclePassageByIdQueryValidator : AbstractValidator<GetVehiclePassageByIdQuery>
{
    public GetVehiclePassageByIdQueryValidator()
    {
        RuleFor(vp => vp.Id).NotEmpty();
    }
}
