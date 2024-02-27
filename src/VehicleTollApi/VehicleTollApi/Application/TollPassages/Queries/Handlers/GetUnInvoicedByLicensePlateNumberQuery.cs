using MediatR;
using VehicleTollApi.Shared;

namespace VehicleTollApi.Application.TollPassages.Queries.Handlers;

public record GetUnInvoicedByLicensePlateNumberQuery(string LicensePlateNumber, DateTimeOffset UntilDateTime) : IRequest<Response<IEnumerable<GetVehiclePassageDto>>>;
