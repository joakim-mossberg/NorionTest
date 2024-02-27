using FluentValidation;
using VehicleTollApi.Application.VehicleOwners.Queries.Handlers;

namespace VehicleTollApi.Application.VehicleOwners.Commands.Validators;

public sealed class GetVehicleOwnerByLicensePlateQueryValidator : AbstractValidator<GetVehicleOwnerByLicensePlateQuery>
{
    public GetVehicleOwnerByLicensePlateQueryValidator()
    {
        RuleFor(vp => vp.LicensePlateNumber).MinimumLength(6).MaximumLength(10);
    }
}
