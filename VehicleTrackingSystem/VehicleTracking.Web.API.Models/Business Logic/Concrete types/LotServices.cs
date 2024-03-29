﻿using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using VehicleTracking_Data_DataAccess;

namespace API.Services
{
    public class LotServices : ILotServices
    {
        internal IUnitOfWork Model { get; }
        internal ILotRepository Lots { get; }

        public LotServices()
        {
            Model = new UnitOfWork();
            Lots = Model.Lots;
        }

        public LotServices(IUnitOfWork someUnitOfWork)
        {
            Model = someUnitOfWork;
            Lots = Model.Lots;
        }

        public Guid AddNewLotFromData(string activeUsername, LotDTO lotDataToAdd)
        {
            if (Utilities.IsNotNull(lotDataToAdd))
            {
                User creator = Model.Users.GetUserWithUsername(activeUsername);
                ICollection<Vehicle> vehicles = GetVehicleList(lotDataToAdd.VehicleVINs);
                return AttemptToAddLot(creator, vehicles, lotDataToAdd);
            }
            else
            {
                throw new ServiceException(ErrorMessages.NullDTOReference);
            }
        }

        private ICollection<Vehicle> GetVehicleList(ICollection<string> vinsToFind)
        {
            ICollection<Vehicle> result = new List<Vehicle>();
            foreach (string VIN in vinsToFind)
            {
                Vehicle vehicleFound = Model.Vehicles.GetVehicleWithVIN(VIN);
                result.Add(vehicleFound);
            }
            return result;
        }

        private Guid AttemptToAddLot(User creator, ICollection<Vehicle> vehicles,
            LotDTO lotData)
        {
            bool nameIsNotRegistered =
                !Lots.ExistsLotWithName(lotData.Name);
            if (nameIsNotRegistered)
            {
                return CreateAndAddLot(creator, vehicles, lotData);
            }
            else
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.FieldMustBeUnique, "nombre de lote");
                throw new ServiceException(errorMessage);
            }
        }

        private Guid CreateAndAddLot(User creator,
            ICollection<Vehicle> vehicles, LotDTO lotData)
        {
            Lot lotToAdd = lotData.ToLot(creator, vehicles);
            MarkVehicleCollectionAsModified(vehicles);
            Lots.AddNewLot(lotToAdd);
            Model.SaveChanges();
            return lotToAdd.Id;
        }

        public IEnumerable<LotDTO> GetRegisteredLots()
        {
            var result = new List<LotDTO>();
            foreach (var lot in Lots.Elements)
            {
                result.Add(LotDTO.FromLot(lot));
            }
            return result.AsReadOnly();
        }

        public LotDTO GetLotByName(string nameToFind)
        {
            Lot lotFound = Lots.GetLotWithName(nameToFind);
            return LotDTO.FromLot(lotFound);
        }

        public void ModifyLotWithName(string nameToModify, LotDTO lotDataToSet)
        {
            ServiceUtilities.CheckParameterIsNotNullAndExecute(lotDataToSet,
            delegate { AttemptToPerformModification(nameToModify, lotDataToSet); });
        }

        private void AttemptToPerformModification(string nameToModify, LotDTO lotData)
        {
            Lot lotFound = Lots.GetLotWithName(nameToModify);
            if (!lotFound.WasTransported)
            {
                ModifyLotWithData(nameToModify, lotData, lotFound);
            }
            else
            {
                throw new ServiceException(ErrorMessages.LotWasTransported);
            }
        }

        private void ModifyLotWithData(string nameToModify, LotDTO lotData, Lot lotFound)
        {
            if (ChangeCausesRepeatedNames(nameToModify, lotData))
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.FieldMustBeUnique, "nombre de lote");
                throw new ServiceException(errorMessage);
            }
            else
            {
                SetLotPropertiesAndSaveChanges(lotData, lotFound);
            }
        }

        private void SetLotPropertiesAndSaveChanges(LotDTO lotData, Lot lotFound)
        {
            ICollection<Vehicle> vehiclesToSet = GetVehicleList(lotData.VehicleVINs);
            MarkAddedAndRemovedVehiclesAsModified(lotFound, vehiclesToSet);
            lotData.SetDataToLot(lotFound, vehiclesToSet);
            Lots.UpdateLot(lotFound);
            Model.SaveChanges();
        }

        private void MarkAddedAndRemovedVehiclesAsModified(Lot lotFound,
            ICollection<Vehicle> vehiclesToSet)
        {
            MarkVehicleCollectionAsModified(vehiclesToSet.Except(lotFound.Vehicles));
            MarkVehicleCollectionAsModified(lotFound.Vehicles.Except(vehiclesToSet));
        }

        private void MarkVehicleCollectionAsModified(IEnumerable<Vehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                Model.Vehicles.UpdateVehicle(vehicle);
            }
        }

        private bool ChangeCausesRepeatedNames(string nameToModify, LotDTO lotData)
        {
            string currentName = Lots.GetLotWithName(nameToModify).Name;
            bool nameChanges = !currentName.Equals(lotData.Name);
            return nameChanges && Lots.ExistsLotWithName(lotData.Name);
        }

        public void RemoveLotWithName(string nameToModify)
        {
            Lot lotToRemove = Lots.GetLotWithName(nameToModify);
            bool wasTransported = lotToRemove.WasTransported;
            if (wasTransported)
            {
                throw new ServiceException(ErrorMessages.CannotRemoveTransportedLots);
            }
            else
            {
                MarkVehicleCollectionAsModified(lotToRemove.Vehicles);
                Lots.RemoveLotWithName(nameToModify);
                Model.SaveChanges();
            }
        }
    }
}