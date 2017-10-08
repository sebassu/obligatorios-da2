using Domain;
using Persistence;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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

        public int AddNewLotFromData(string activeUsername, LotDTO lotDataToAdd)
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

        private int AttemptToAddLot(User creator, ICollection<Vehicle> vehicles,
            LotDTO lotData)
        {
            bool nameIsNotRegistered =
                !Lots.ExistsLotWithName(lotData.Name);
            if (nameIsNotRegistered)
            {
                Lot lotToAdd = lotData.ToLot(creator, vehicles);
                MarkVehicleCollectionAsModified(vehicles);
                Lots.AddNewLot(lotToAdd);
                Model.SaveChanges();
                return lotToAdd.Id;
            }
            else
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.FieldMustBeUnique, "nombre de lote");
                throw new ServiceException(errorMessage);
            }
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
            Lot lotFound = Lots.GetLotByName(nameToFind);
            return LotDTO.FromLot(lotFound);
        }

        public void ModifyLotWithName(string nameToModify, LotDTO lotDataToSet)
        {
            if (!Lots.GetLotByName(nameToModify).WasTransported)
            {
                ServiceUtilities.CheckParameterIsNotNullAndExecute(lotDataToSet,
                delegate { AttemptToPerformModification(nameToModify, lotDataToSet); });
            }
            else
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.LotWasTransported);
                throw new ServiceException(errorMessage);
            }
        }

        private void AttemptToPerformModification(string nameToModify, LotDTO lotData)
        {
            if (ChangeCausesRepeatedNames(nameToModify, lotData))
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.FieldMustBeUnique, "nombre de lote");
                throw new ServiceException(errorMessage);
            }
            else
            {
                Lot lotFound = Lots.GetLotByName(nameToModify);
                ICollection<Vehicle> vehiclesToSet = GetVehicleList(lotData.VehicleVINs);
                MarkAddedAndRemovedVehiclesAsModified(lotFound, vehiclesToSet);
                lotData.SetDataToLot(lotFound, vehiclesToSet);
                Lots.UpdateLot(lotFound);
                Model.SaveChanges();
            }
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
            string currentName = Lots.GetLotByName(nameToModify).Name;
            bool nameChanges = !currentName.Equals(lotData.Name);
            return nameChanges && Lots.ExistsLotWithName(lotData.Name);
        }

        public void RemoveLotWithName(string nameToModify)
        {
            Lot lotToRemove = Lots.GetLotByName(nameToModify);
            bool wasTransported = lotToRemove.WasTransported;
            if (wasTransported)
            {
                throw new ServiceException(ErrorMessages.CannotRemoveTransportedLots);
            }
            else
            {
                MarkVehicleCollectionAsModified(lotToRemove.Vehicles);
                lotToRemove.Vehicles = new List<Vehicle>();
                Lots.RemoveLotWithName(nameToModify);
                Model.SaveChanges();
            }
        }
    }
}