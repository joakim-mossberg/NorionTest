using FluentValidation;
using VehicleTollApi.Application.Vehicles.Queries.Handlers;

namespace VehicleTollApi.Application.Vehicles.Commands.Validators;

public sealed class GetVehiclesByLicensePlateQueryValidator : AbstractValidator<GetVehiclesByLicensePlateQuery>
{
    public GetVehiclesByLicensePlateQueryValidator()
    {
        RuleFor(vp => vp.LicensePlateNumber).MinimumLength(1).MaximumLength(10);
    }
}
