using FluentValidation;
using VehicleTollApi.Application.Vehicles.Commands.Handlers;

namespace VehicleTollApi.Application.Vehicles.Commands.Validators;

public sealed class GetAllVehiclesQueryValidator : AbstractValidator<CreateVehicleCommand>
{
    public GetAllVehiclesQueryValidator()
    {
    }
}
