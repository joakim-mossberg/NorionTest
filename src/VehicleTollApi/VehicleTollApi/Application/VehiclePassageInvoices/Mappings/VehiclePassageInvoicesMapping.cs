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
}
