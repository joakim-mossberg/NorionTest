using FluentValidation;
using VehicleTollApi.Application.VehiclePassageInvoices.Queries.Handlers;

namespace VehicleTollApi.Application.VehiclePassageInvoices.Queries.Validators;

public class GetVehiclePassageInvoicesByOwnerIdQueryValidator : AbstractValidator<GetVehiclePassageInvoicesByOwnerIdQuery>
{
    public GetVehiclePassageInvoicesByOwnerIdQueryValidator()
    {
        RuleFor(v => v.OwnerId).NotEmpty();
    }
}
