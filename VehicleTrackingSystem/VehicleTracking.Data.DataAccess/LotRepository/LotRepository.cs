using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VehicleTracking.Data.Tests")]
namespace VehicleTracking_Data_DataAccess
{
    internal class LotRepository : GenericRepository<Lot>, ILotRepository
    {
        public LotRepository(VTSystemContext someContext) : base(someContext) { }

        public void AddNewLot(Lot lotToAdd)
        {
            Add(lotToAdd);
        }

        public IEnumerable<Lot> Elements => GetElementsWith("Creator," +
            "AssociatedTransport,Vehicles.StagesData.Inspections");

        public Lot GetLotWithName(string nameToFind)
        {
            try
            {
                return elements.Include("Creator").Include("AssociatedTransport")
                    .Include("Vehicles.StagesData.Inspections").Single(l => l.Name.Equals(nameToFind));
            }
            catch (InvalidOperationException)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.CouldNotFindField, "nombre de lote", nameToFind);
                throw new RepositoryException(errorMessage);
            }
        }

        public void UpdateLot(Lot lotToModify)
        {
            Update(lotToModify);
        }

        public void RemoveLotWithName(string nameToRemove)
        {
            var lotToRemove = GetLotWithName(nameToRemove);
            AttemptToRemove(lotToRemove);
        }

        internal override bool ElementExistsInCollection(Lot value)
        {
            return Utilities.IsNotNull(value) && elements.Any(l => l.Id == value.Id);
        }

        public bool ExistsLotWithName(string nameToFind)
        {
            return elements.Any(l => l.Name.Equals(nameToFind));
        }
    }
}