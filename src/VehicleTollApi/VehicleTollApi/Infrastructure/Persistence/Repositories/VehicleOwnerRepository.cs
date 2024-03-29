﻿using VehicleTollApi.Infrastructure.Persistence.Data;
using VehicleTollApi.Infrastructure.Persistence.Models;
using VehicleTollApi.Infrastructure.Persistence.RepositoryInterfaces;

namespace VehicleTollApi.Infrastructure.Persistence.Repositories;

public class VehicleOwnerRepository : RepositoryBase<VehicleOwner>, IVehicleOwnerRepository
{
    public VehicleOwnerRepository(VehicleTollContext repositoryContext)
            : base(repositoryContext) { }
}
