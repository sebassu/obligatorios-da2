using System;
using Persistence;
using System.Collections.Generic;
using Domain;

namespace API.Services.Business_Logic.Concrete_types
{
    public class InspectionServices : IInspectionServices
    {
        internal IUnitOfWork Model { get; }
        internal IInspectionRepository Inspections { get; }

        public int AddNewInspectionFromData(string vehicleVIN,
            InspectionDTO inspectionDataToAdd)
        {
            Inspection inspectionToAdd = CreateInspectionFromDTOData(vehicleVIN, inspectionDataToAdd);
            Inspections.AddNewInspection(inspectionToAdd);
            Model.SaveChanges();
            return inspectionDataToAdd.Id;
        }

        private Inspection CreateInspectionFromDTOData(string vehicleVIN, InspectionDTO inspectionDataToAdd)
        {
            Vehicle vehicleToSet = Model.Vehicles.GetVehicleWithVIN(vehicleVIN);
            User responsible = Model.Users.GetUserWithUsername(inspectionDataToAdd.ResponsibleUsername);
            Location locationToSet = Model.Locations.GetLocationWithName(inspectionDataToAdd.LocationName);
            Inspection inspectionToAdd = inspectionDataToAdd.ToInspection(responsible, locationToSet, vehicleToSet);
            return inspectionToAdd;
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
    }
}