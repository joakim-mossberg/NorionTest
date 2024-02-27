using FluentValidation;
using VehicleTollApi.Application.TollPassages.Queries.Handlers;

namespace VehicleTollApi.Application.TollPassages.Queries.Validators;

public class GetUnInvoicedByLicensePlateNumberQueryValidator : AbstractValidator<GetUnInvoicedByLicensePlateNumberQuery>
{
    public GetUnInvoicedByLicensePlateNumberQueryValidator()
    {
        RuleFor(vp => vp.LicensePlateNumber).MinimumLength(1).MaximumLength(10);
        RuleFor(vp => vp.UntilDateTime).NotEmpty();
    }
}
