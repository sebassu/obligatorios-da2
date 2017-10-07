using Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


[assembly: InternalsVisibleTo("VehicleTracking.Data.Tests")]
namespace Persistence
{
   internal class LotRepository : GenericRepository<Lot>, ILotRepository
    {
        public LotRepository(VTSystemContext someContext) : base(someContext) { }

        public IEnumerable<Lot> Elements => GetElementsThat();

        public Lot GetLotById(int IdToFind)
        {
            try
            {
                return elements.Single(l => l.Id.Equals(IdToFind));
            }
            catch (InvalidOperationException)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.CouldNotFindField, "Id", IdToFind);
                throw new RepositoryException(errorMessage);
            }
        }

        public void AddNewLot(Lot lotToAdd)
        {
            Add(lotToAdd);
        }
        public Lot GetLotWithId(int IdToFind)
        {
            try
            {
                return elements.Single(l => l.Id.Equals(IdToFind));
            }
            catch (InvalidOperationException)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.CouldNotFindField, "Id", IdToFind);
                throw new RepositoryException(errorMessage);
            }
        }

        public void RemoveLotWithId(int IdToRemove)
        {
            var lotToRemove = GetLotWithId(IdToRemove);
            AttemptToRemove(lotToRemove);
        }

        protected override bool ElementExistsInCollection(Lot value)
        {
            return Utilities.IsNotNull(value) && elements.Any(l => l.Id == value.Id);
        }

        public void UpdateLot(Lot lotToModify)
        {
            Update(lotToModify);
        }


    }
}
