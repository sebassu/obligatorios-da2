﻿using System;

namespace Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IVehicleRepository Vehicles { get; }
        IZoneRepository Zones { get; }
        ISubzoneRepository Subzones { get; }
        ILotRepository Lots { get; }
        void SaveChanges();
        void DeleteAllDataFromDatabase();
    }
}