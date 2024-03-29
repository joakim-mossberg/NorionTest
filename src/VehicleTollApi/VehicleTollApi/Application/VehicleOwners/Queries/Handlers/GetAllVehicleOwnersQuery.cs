﻿using MediatR;
using VehicleTollApi.Shared;

namespace VehicleTollApi.Application.VehicleOwners.Queries.Handlers;

public record GetAllVehicleOwnersQuery() : IRequest<Response<IEnumerable<GetVehicleOwnerDto>>>;
