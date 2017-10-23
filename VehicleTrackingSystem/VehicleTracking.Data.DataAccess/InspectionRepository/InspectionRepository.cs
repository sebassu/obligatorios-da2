using Domain;
using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace Persistence
{
    internal class InspectionRepository : GenericRepository<Inspection>,
        IInspectionRepository
    {
        public InspectionRepository(VTSystemContext someContext)
            : base(someContext) { }

        public IEnumerable<Inspection> Elements => GetElementsWith(null,
            "ResponsibleUser,Location");

        public void AddNewInspection(Inspection inspectionToAdd)
        {
            Add(inspectionToAdd);
            context.Damages.AddRange(inspectionToAdd.Damages);
        }

        public Inspection GetInspectionWithId(int idToLookup)
        {
            try
            {
                return elements.Include("ResponsibleUser").Include("Location")
                    .Include("Damages.Images").Single(i => i.Id == idToLookup);
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