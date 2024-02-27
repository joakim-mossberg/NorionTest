using FluentValidation;
using MediatR;
using VehicleTollApi.Application.TollPassages.Mappings;
using VehicleTollApi.Infrastructure.Persistence;
using VehicleTollApi.Shared;

namespace VehicleTollApi.Application.TollPassages.Queries.Handlers;

public class GetUnInvoicedByLicensePlateNumberHandler : IRequestHandler<GetUnInvoicedByLicensePlateNumberQuery, Response<IEnumerable<GetVehiclePassageDto>>>
{
    private IRepositoryWrapper _repositoryWrapper;
    private IValidator<GetUnInvoicedByLicensePlateNumberQuery> _validator;

    public GetUnInvoicedByLicensePlateNumberHandler(IRepositoryWrapper repositoryWrapper,
        IValidator<GetUnInvoicedByLicensePlateNumberQuery> validator)
    {
        _repositoryWrapper = repositoryWrapper;
        _validator = validator;
    }

    public async Task<Response<IEnumerable<GetVehiclePassageDto>>> Handle(GetUnInvoicedByLicensePlateNumberQuery request, CancellationToken cancellationToken)
    {
        var validateResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validateResult.IsValid)
        {
            return new Response<IEnumerable<GetVehiclePassageDto>>(null!, validateResult.Errors);
        }

        var uninvoicedPassages = _repositoryWrapper.VehiclePassage
            .FindByCondition(passage => passage.LicensePlateNumber == request.LicensePlateNumber
                                        && passage.PassageDateTime <= request.UntilDateTime
                                        && passage.VehiclePassageInvoice == null);

        return new Response<IEnumerable<GetVehiclePassageDto>>(uninvoicedPassages.Select(passage => passage.AsDto()));
    }
}
