using FluentValidation;
using VehicleTollApi.Application.Vehicles.Queries.Handlers;

namespace VehicleTollApi.Application.Vehicles.Queries.Validators;

public sealed class GetAllVehiclesQueryValidator : AbstractValidator<GetAllVehiclesQuery>
{
    public GetAllVehiclesQueryValidator()
    {
    }
}
