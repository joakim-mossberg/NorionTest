using FluentValidation;
using VehicleTollApi.Application.VehiclePassageInvoices.Commands.Handlers;

namespace VehicleTollApi.Application.VehicleOwners.Mappings;

public class CreateVehiclePassageInvoiceCommandValidator : AbstractValidator<CreateVehiclePassageInvoiceCommand>
{
    public CreateVehiclePassageInvoiceCommandValidator()
    {
        RuleFor(v => v.VehicleKind).NotEmpty();
        RuleFor(v => v.OwnerId).NotEmpty();
        RuleFor(v => v.Passages.Any());
    }
}
