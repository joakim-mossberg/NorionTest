﻿using System.Runtime.CompilerServices;
using VehicleTollApi.Application.TollPassages.Commands.Handlers;
using VehicleTollApi.Application.TollPassages.Queries.Handlers;
using VehicleTollApi.Infrastructure.Persistence.Models;

namespace VehicleTollApi.Application.TollPassages.Mappings;

public static class VehiclePassageMappings
{
    public static VehiclePassage AsModel(this AddVehiclePassageCommand vehiclePassageCommand)
    {
        return new VehiclePassage()
        {
            LicensePlateNumber = vehiclePassageCommand.LicensePlateNumber,
            PassageDateTime = vehiclePassageCommand.PassageDateTime,
        };
    }

    public static AddVehiclePassageDto AsNewDto(this VehiclePassage vehiclePassage)
    {
        if (vehiclePassage is null)
        {
            return null!;
        }
        return new AddVehiclePassageDto(vehiclePassage.Id, vehiclePassage.LicensePlateNumber!, vehiclePassage.PassageDateTime);    
    }

    public static GetVehiclePassageDto AsDto(this VehiclePassage vehiclePassage)
    {
        if (vehiclePassage is null)
        {
            return null!;
        }
        return new GetVehiclePassageDto(vehiclePassage.Id, vehiclePassage.LicensePlateNumber!, vehiclePassage.PassageDateTime);
    }
}
