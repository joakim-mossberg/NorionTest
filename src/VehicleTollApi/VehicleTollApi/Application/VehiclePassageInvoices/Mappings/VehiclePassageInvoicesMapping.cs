using VehicleTollApi.Application.VehiclePassageInvoices.Commands.Handlers;
using VehicleTollApi.Application.VehiclePassageInvoices.Queries.Handlers;
using VehicleTollApi.Infrastructure.Persistence.Models;

namespace VehicleTollApi.Application.VehiclePassageInvoices.Mappings;

public static class VehiclePassageInvoicesMapping
{
    public static GetVehiclePassageInvoiceDto AsDto(this VehiclePassageInvoice invoice)
    {
        if (invoice is null)
        {
            return null!;
        }
        return new GetVehiclePassageInvoiceDto(invoice.Id, invoice.Amount, invoice.InvoiceDateTime);
    }

    public static CreatedVehiclePassageInvoiceDto AsNewDto(this VehiclePassageInvoice invoice)
    {
        if (invoice is null)
        {
            return null!;
        }
        return new CreatedVehiclePassageInvoiceDto(invoice.Id, invoice.Amount, invoice.InvoiceDateTime, invoice.VehicleOwnerId);
    }

}
