using FluentValidation;
using MediatR;
using VehicleTollApi.Infrastructure.Persistence;
using VehicleTollApi.Shared;
using VehicleTollApi.Application.VehiclePassageInvoices.Mappings;

namespace VehicleTollApi.Application.VehiclePassageInvoices.Queries.Handlers;

public class GetAllVehiclePassageInvoicesHandler : IRequestHandler<GetAllVehiclePassageInvoicesQuery, Response<IEnumerable<GetVehiclePassageInvoiceDto>>>
{
    private IRepositoryWrapper _repositoryWrapper;
    private IValidator<GetAllVehiclePassageInvoicesQuery> _validator;

    public GetAllVehiclePassageInvoicesHandler(IRepositoryWrapper repositoryWrapper,
        IValidator<GetAllVehiclePassageInvoicesQuery> validator)
    {
        _repositoryWrapper = repositoryWrapper;
        _validator = validator;
    }

    public async Task<Response<IEnumerable<GetVehiclePassageInvoiceDto>>> Handle(GetAllVehiclePassageInvoicesQuery request, CancellationToken cancellationToken)
    {
        var validateResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validateResult.IsValid)
        {
            return new Response<IEnumerable<GetVehiclePassageInvoiceDto>>(null!, validateResult.Errors);
        }

        var invoices = _repositoryWrapper.VehiclePassageInvoice.FindAll();
        return new Response<IEnumerable<GetVehiclePassageInvoiceDto>>(invoices.Select(invoice => invoice.AsDto()));
    }
}
