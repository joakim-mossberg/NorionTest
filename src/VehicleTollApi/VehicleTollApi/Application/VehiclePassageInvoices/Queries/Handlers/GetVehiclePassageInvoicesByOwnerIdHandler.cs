using FluentValidation;
using MediatR;
using VehicleTollApi.Application.VehiclePassageInvoices.Mappings;
using VehicleTollApi.Infrastructure.Persistence;
using VehicleTollApi.Shared;

namespace VehicleTollApi.Application.VehiclePassageInvoices.Queries.Handlers;

public class GetVehiclePassageInvoicesByOwnerIdHandler : IRequestHandler<GetVehiclePassageInvoicesByOwnerIdQuery, Response<IEnumerable<GetVehiclePassageInvoiceDto>>>
{
    private IRepositoryWrapper _repositoryWrapper;
    private IValidator<GetVehiclePassageInvoicesByOwnerIdQuery> _validator;

    public GetVehiclePassageInvoicesByOwnerIdHandler(IRepositoryWrapper repositoryWrapper,
        IValidator<GetVehiclePassageInvoicesByOwnerIdQuery> validator)
    {
        _repositoryWrapper = repositoryWrapper;
        _validator = validator;
    }

    public async Task<Response<IEnumerable<GetVehiclePassageInvoiceDto>>> Handle(GetVehiclePassageInvoicesByOwnerIdQuery request, CancellationToken cancellationToken)
    {
        var validateResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validateResult.IsValid)
        {
            return new Response<IEnumerable<GetVehiclePassageInvoiceDto>>(null!, validateResult.Errors);
        }

        var invoices = _repositoryWrapper.VehiclePassageInvoice
            .FindByCondition(invoice => invoice.VehicleOwnerId == request.OwnerId);
        return new Response<IEnumerable<GetVehiclePassageInvoiceDto>>(invoices.Select(invoice => invoice.AsDto()));
    }
}
