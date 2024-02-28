using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Routing.Constraints;
using System.Runtime.InteropServices;
using VehicleTollApi.Infrastructure.Persistence;
using VehicleTollApi.Infrastructure.Persistence.Models;
using VehicleTollApi.Shared;
using VehicleTollApi.Shared.Enums;

namespace VehicleTollApi.Application.VehiclePassageInvoices.Commands.Handlers;

public class CreateVehiclePassageInvoiceHandler : IRequestHandler<CreateVehiclePassageInvoiceCommand
    , Response<CreatedVehiclePassageInvoiceDto>>
{
    private IRepositoryWrapper _repositoryWrapper;
    private IValidator<CreateVehiclePassageInvoiceCommand> _validator;

    public CreateVehiclePassageInvoiceHandler(IRepositoryWrapper repositoryWrapper,
        IValidator<CreateVehiclePassageInvoiceCommand> validator)
    {
        _repositoryWrapper = repositoryWrapper;
        _validator = validator;
    }

    public async Task<Response<CreatedVehiclePassageInvoiceDto>> Handle(CreateVehiclePassageInvoiceCommand request
        , CancellationToken cancellationToken)
    {
        var validateResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validateResult.IsValid)
        {
            return new Response<CreatedVehiclePassageInvoiceDto>(null!, validateResult.Errors);
        }

        var newInvoice = new VehiclePassageInvoice();
        newInvoice.VehicleOwnerId = request.OwnerId;
        newInvoice.InvoiceDateTime = DateTimeOffset.Now;
        newInvoice.Amount = CalculateTollFeeToBeInvoiced(request);
        _repositoryWrapper.VehiclePassageInvoice.Create(newInvoice);
        _repositoryWrapper.Save();

        var passageIds = request.Passages.Select(passage => passage.Id);
        _repositoryWrapper.VehiclePassage
            .ExecuteUpdatePassages(passage => passageIds.Contains(passage.Id), newInvoice.Id);
        _repositoryWrapper.Save();
    }

    private decimal CalculateTollFeeToBeInvoiced(CreateVehiclePassageInvoiceCommand request)
    {
        if (IsTollFreeVehicle(request.VehicleKind))
        {
            return 0;
        }
        decimal totalAmount = 0;
        var passageDates = request.Passages
            .OrderBy(p => p.PassageDateTime)
            .GroupBy(p => p.PassageDateTime.Date);

        foreach (var passageDate in passageDates)
        {
            totalAmount += DailyToll(request.VehicleKind, passageDate);
        }
        return totalAmount;
    }

    private decimal DailyToll(VehicleKind vehicleKind, IGrouping<DateTime, VehiclePassage> passageDate)
    {
        decimal dailyToll = 0;
        DateTimeOffset intervalStart = passageDate.Key; // Start of the first interval
        decimal highestFeeInInterval = 0;

        foreach (var passage in passageDate)
        {
            if (passage.PassageDateTime > intervalStart.AddMinutes(60))
            {
                // End of the interval, add the highest fee so far
                dailyToll += highestFeeInInterval;
                intervalStart = passage.PassageDateTime;
                highestFeeInInterval = 0;
            }

            highestFeeInInterval = Math.Max(highestFeeInInterval, GetTollFee(passage.PassageDateTime, vehicleKind));
        }

        // Handle the last interval (might not have been added yet)
        dailyToll += highestFeeInInterval;

        return Math.Max(dailyToll, 60);
    }

    private decimal GetTollFee(DateTimeOffset date, VehicleKind vehicleKind)
    {
        if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicleKind)) return 0;

        int hour = date.Hour;
        int minute = date.Minute;

        if (hour == 6 && minute >= 0 && minute <= 29) return 8;
        else if (hour == 6 && minute >= 30 && minute <= 59) return 13;
        else if (hour == 7 && minute >= 0 && minute <= 59) return 18;
        else if (hour == 8 && minute >= 0 && minute <= 29) return 13;
        else if (hour >= 8 && hour <= 14 && minute >= 30 && minute <= 59) return 8;
        else if (hour == 15 && minute >= 0 && minute <= 29) return 13;
        else if (hour == 15 && minute >= 0 || hour == 16 && minute <= 59) return 18;
        else if (hour == 17 && minute >= 0 && minute <= 59) return 13;
        else if (hour == 18 && minute >= 0 && minute <= 29) return 8;
        else return 0;
    }

    private bool IsTollFreeVehicle(VehicleKind vehicleKind) => vehicleKind > VehicleKind.Car;

    private Boolean IsTollFreeDate(DateTimeOffset date)
    {
        int year = date.Year;
        int month = date.Month;
        int day = date.Day;

        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;
        if (date.TimeOfDay < TimeSpan.FromHours(6) || date.TimeOfDay > TimeSpan.FromMinutes(18 * 60 + 29)) return true;

        if (month == 7) return true;

        if (year == 2013)
        {
            if (month == 1 && day == 1 ||
                month == 3 && (day == 28 || day == 29) ||
                month == 4 && (day == 1 || day == 30) ||
                month == 5 && (day == 1 || day == 8 || day == 9) ||
                month == 6 && (day == 5 || day == 6 || day == 21) ||
                month == 11 && day == 1 ||
                month == 12 && (day == 24 || day == 25 || day == 26 || day == 31))
            {
                return true;
            }
        }
        return false;
    }
}
