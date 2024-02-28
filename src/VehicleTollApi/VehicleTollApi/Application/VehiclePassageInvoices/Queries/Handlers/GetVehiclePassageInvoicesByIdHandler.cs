using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using VehicleTollApi.Application.VehiclePassageInvoices.Mappings;
using VehicleTollApi.Infrastructure.Persistence;
using VehicleTollApi.Shared;

namespace VehicleTollApi.Application.VehiclePassageInvoices.Queries.Handlers;

public class GetVehiclePassageInvoicesByIdHandler : IRequestHandler<GetVehiclePassageInvoicesByIdQuery, Response<GetVehiclePassageInvoiceDto>>
{
    private IRepositoryWrapper _repositoryWrapper;
    private IValidator<GetVehiclePassageInvoicesByIdQuery> _validator;

    public GetVehiclePassageInvoicesByIdHandler(IRepositoryWrapper repositoryWrapper,
        IValidator<GetVehiclePassageInvoicesByIdQuery> validator)
    {
        _repositoryWrapper = repositoryWrapper;
        _validator = validator;
    }

    public async Task<Response<GetVehiclePassageInvoiceDto>> Handle(GetVehiclePassageInvoicesByIdQuery request, CancellationToken cancellationToken)
    {
        var validateResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validateResult.IsValid)
        {
            return new Response<GetVehiclePassageInvoiceDto>(null!, validateResult.Errors);
        }

        var invoice = await _repositoryWrapper.VehiclePassageInvoice
            .FindByCondition(invoice => invoice.Id == request.Id)
            .FirstOrDefaultAsync();
        return new Response<GetVehiclePassageInvoiceDto>(invoice?.AsDto()!);
    }
}
