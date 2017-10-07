using Domain;
using Persistence;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    class LotServices : ILotServices
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

        public int AddNewLotFromData(LotDTO lotDataToAdd)
        {
            if (Utilities.IsNotNull(lotDataToAdd))
            {
                User creator = Model.Users.GetUserWithUsername(lotDataToAdd.CreatorName);
                ICollection<Vehicle> vehicles = GetVehicleList(lotDataToAdd.VehicleVINs);
                return AttemptToAddLot(creator, vehicles, lotDataToAdd);
            }
            else
            {
                throw new ServiceException(ErrorMessages.NullDTOReference);
            }
        }

        private int AttemptToAddLot(User creator, ICollection<Vehicle> vehicles, LotDTO lotData)
        {
            bool nameIsNotRegistered = !Lots.ExistsLotWithName(lotData.Name);
            if (nameIsNotRegistered)
            {
                Lot lotToAdd = lotData.ToLot(creator, vehicles);
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

        private ICollection<Vehicle> GetVehicleList(ICollection<string> list)
        {
            ICollection<Vehicle> vehicles = new List<Vehicle>();
            foreach(string v in list)
            {
                vehicles.Add(Model.Vehicles.GetVehicleWithVIN(v));
            }
            return vehicles;
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

        public void ModifyLotWithName(string nameToModify, LotDTO lotDataToSet, ICollection<Vehicle> vehicles)
        {
            if (!Lots.GetLotByName(nameToModify).WasTransported)
            {
                ServiceUtilities.CheckParameterIsNotNullAndExecute(lotDataToSet,
                delegate { AttemptToPerformModification(nameToModify, lotDataToSet, vehicles); });
            }
            else
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.LotWasTransported);
                throw new ServiceException(errorMessage);
            }
        }

        private void AttemptToPerformModification(string nameToModify, LotDTO lotData, ICollection<Vehicle> vehicles)
        {
            if (ChangeCausesRepeatedNames(nameToModify ,lotData))
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.FieldMustBeUnique, "nombre de lote");
                throw new ServiceException(errorMessage);
            }
            else
            {
                Lot lotFound = Lots.GetLotByName(nameToModify);
                lotData.SetDataToLot(lotFound, vehicles);
                Lots.UpdateLot(lotFound);
                Model.SaveChanges();
            }
        }

        private bool ChangeCausesRepeatedNames(string nameToModify, LotDTO lotData)
        {
            string currentName = Lots.GetLotByName(nameToModify).Name;
            bool nameChanges = !currentName.Equals(lotData.Name);
            return nameChanges && Lots.ExistsLotWithName(lotData.Name);
        }

        public void RemoveZoneWithName(string nameToModify)
        {
            Lot lotToRemove = Lots.GetLotByName(nameToModify);
            bool wasTransported = lotToRemove.WasTransported;
            if (wasTransported)
            {
                throw new ServiceException(ErrorMessages.CannotRemoveTransportedLots);
            }
            else
            {
                Lots.RemoveLotWithName(nameToModify);
                Model.SaveChanges();
            }
        }
    }
}
