using Domain;
using System;
using System.Collections.Generic;
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

        public void AddNewLot(Lot lotToAdd)
        {
            Add(lotToAdd);
        }

        protected override bool ElementExistsInCollection(Lot value)
        {
            return Utilities.IsNotNull(value) && elements.Any(l => l.Id == value.Id);
        }


    }
}
