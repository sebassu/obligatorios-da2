using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
{
    internal class InspectionRepository : GenericRepository<Inspection>,
        IInspectionRepository
    {
        public InspectionRepository(VTSystemContext someContext)
            : base(someContext) { }

        public IEnumerable<Inspection> Elements => GetElementsWith("Responsible," +
            "Location");

        public void AddNewInspection(Inspection inspectionToAdd)
        {
            Add(inspectionToAdd);
            AddDamagesToDatabase(inspectionToAdd);
        }

        private void AddDamagesToDatabase(Inspection inspectionToAdd)
        {
            foreach (var damage in inspectionToAdd.Damages)
            {
                context.ImageElements.AddRange(damage.ImageElements);
                context.Damages.Add(damage);
            }
        }

        public Inspection GetInspectionWithId(Guid idToLookup)
        {
            try
            {
                return elements.Include("Responsible").Include("Location")
                    .Include("Damages.ImageElements").Single(i => i.Id == idToLookup);
            }
            catch (InvalidOperationException)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.CouldNotFindField, "identificador de inspección", idToLookup);
                throw new RepositoryException(errorMessage);
            }
        }
    }
}