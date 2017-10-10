﻿using Domain;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System;
using System.Data.Entity;

[assembly: InternalsVisibleTo("VehicleTracking.Web.API.Services")]
namespace Persistence
{
    internal class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(VTSystemContext someContext) : base(someContext) { }

        public IEnumerable<Vehicle> Elements => GetElementsWith(null, "StagesData");

        public void AddNewVehicle(Vehicle vehicleToAdd)
        {
            Add(vehicleToAdd);
            context.ProcessDatas.Add(vehicleToAdd.StagesData);
        }

        public bool ExistsVehicleWithVIN(string VINToLookup)
        {
            return elements.Any(v => v.VIN.Equals(VINToLookup));
        }

        public Vehicle GetVehicleWithVIN(string vinToFind)
        {
            return AttemptToExecuteActionWithVIN(VehicleBasicData, vinToFind);
        }

        private Vehicle VehicleBasicData(string vinToFind)
        {
            return elements.Include("StagesData.PortLot").Include("StagesData.TransportData")
                .Include("StagesData.Inspections").Include("StagesData.YardMovements")
                .Include("StagesData.YardCurrentLocation")
                .Single(v => v.VIN.Equals(vinToFind));
        }

        public Vehicle GetFullyLoadedVehicleWithVIN(string vinToLookup)
        {
            return AttemptToExecuteActionWithVIN(VehicleFullData, vinToLookup);
        }

        private Vehicle VehicleFullData(string vinToLookup)
        {
            return elements.Include("StagesData.PortLot.Creator").Include("StagesData.PortLot.Vehicles")
                .Include("StagesData.Inspections.ResponsibleUser").Include("StagesData.Inspections.Damages")
                .Include("StagesData.Inspections.Location").Include("StagesData.TransportData.Transporter")
                .Include("StagesData.TransportData.LotsTransported").Include("StagesData.YardMovements.Departure.Container")
                .Include("StagesData.YardMovements.Arrival.Container").Include("StagesData.YardMovements.ResponsibleUser")
                .Single(v => v.VIN.Equals(vinToLookup));
        }

        public Vehicle AttemptToExecuteActionWithVIN(Func<string, Vehicle> actionToExecute,
            string vinToLookup)
        {
            try
            {
                return actionToExecute.Invoke(vinToLookup);
            }
            catch (InvalidOperationException)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.CouldNotFindField, "VIN", vinToLookup);
                throw new RepositoryException(errorMessage);
            }
        }

        public void UpdateVehicle(Vehicle modifiedVehicle)
        {
            Update(modifiedVehicle);
            context.Entry(modifiedVehicle.StagesData).State
                = EntityState.Modified;
        }

        public void RemoveVehicleWithVIN(string vinToRemove)
        {
            var vehicleToRemove = GetVehicleWithVIN(vinToRemove);
            AttemptToRemove(vehicleToRemove);
        }

        protected override bool ElementExistsInCollection(Vehicle value)
        {
            return Utilities.IsNotNull(value) && elements.Any(v => v.Id == value.Id);
        }
    }
}