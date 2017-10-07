using Persistence;
using System.Collections.Generic;
using Domain;

namespace API.Services
{
    public class InspectionServices : IInspectionServices
    {
        internal IUnitOfWork Model { get; }
        internal IInspectionRepository Inspections { get; }

        public InspectionServices()
        {
            Model = new UnitOfWork();
            Inspections = Model.Inspections;
        }

        public InspectionServices(IUnitOfWork someUnitOfWork)
        {
            Model = someUnitOfWork;
            Inspections = Model.Inspections;
        }

        public int AddNewPortInspectionFromData(string vehicleVIN, string currentUsername,
            InspectionDTO inspectionDataToAdd)
        {
            ValidateNonNullDTO(inspectionDataToAdd);
            Vehicle vehicleToSet = Model.Vehicles.GetVehicleWithVIN(vehicleVIN);
            Inspection inspectionToAdd = CreateInspectionFromDTOData(vehicleToSet,
                currentUsername, inspectionDataToAdd);
            vehicleToSet.PortInspection = inspectionToAdd;
            return AddNewDataAndSaveChanges(inspectionDataToAdd, vehicleToSet,
                inspectionToAdd);
        }

        public int AddNewYardInspectionFromData(string vehicleVIN, string currentUsername,
            InspectionDTO inspectionDataToAdd)
        {
            ValidateNonNullDTO(inspectionDataToAdd);
            Vehicle vehicleToSet = Model.Vehicles.GetVehicleWithVIN(vehicleVIN);
            Inspection inspectionToAdd = CreateInspectionFromDTOData(vehicleToSet, currentUsername,
                inspectionDataToAdd);
            vehicleToSet.YardInspection = inspectionToAdd;
            return AddNewDataAndSaveChanges(inspectionDataToAdd,
                vehicleToSet, inspectionToAdd);
        }

        private Inspection CreateInspectionFromDTOData(Vehicle vehicleToSet,
            string currentUsername, InspectionDTO inspectionDataToAdd)
        {
            User responsible = Model.Users.GetUserWithUsername(currentUsername);
            Location locationToSet = Model.Locations.GetLocationWithName(inspectionDataToAdd.LocationName);
            Inspection inspectionToAdd = inspectionDataToAdd.ToInspection(responsible,
                locationToSet, vehicleToSet);
            return inspectionToAdd;
        }

        private int AddNewDataAndSaveChanges(InspectionDTO inspectionDataToAdd,
            Vehicle vehicleToSet, Inspection inspectionToAdd)
        {
            Inspections.AddNewInspection(inspectionToAdd);
            Model.Vehicles.UpdateVehicle(vehicleToSet);
            Model.SaveChanges();
            return inspectionDataToAdd.Id;
        }

        public InspectionDTO GetInspectionWithId(int idToLookup)
        {
            Inspection inspectionFound = Inspections.GetInspectionWithId(idToLookup);
            return InspectionDTO.FromInspection(inspectionFound);
        }

        public IEnumerable<InspectionDTO> GetRegisteredInspections()
        {
            var result = new List<InspectionDTO>();
            foreach (var inspection in Inspections.Elements)
            {
                result.Add(InspectionDTO.FromInspection(inspection));
            }
            return result.AsReadOnly();
        }

        private void ValidateNonNullDTO(InspectionDTO someDTO)
        {
            if (Utilities.IsNull(someDTO))
            {
                throw new ServiceException(ErrorMessages.NullDTOReference);
            }
        }
    }
}