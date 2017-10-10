using System;
using Domain;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace Persistence
{
    internal class TransportRepository : GenericRepository<Transport>, ITransportRepository
    {
        public TransportRepository(VTSystemContext someContext)
            : base(someContext) { }

        public void AddNewTransport(Transport transportToAdd)
        {
            Add(transportToAdd);
        }

        public IEnumerable<Transport> Elements => GetElementsWith(null,
            "Transporter,LotsTransported");

        public Transport GetTransportWithId(int idToLookup)
        {
            try
            {
                return elements.Include("Transporter").Include("LotsTransported.Vehicles.StagesData")
                    .Single(t => t.Id == idToLookup);
            }
            catch (InvalidOperationException)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.CouldNotFindField, "identificador de transporte", idToLookup);
                throw new RepositoryException(errorMessage);
            }
        }

        public void UpdateTransport(Transport transportToModify)
        {
            Update(transportToModify);
        }

        protected override bool ElementExistsInCollection(Transport entityToUpdate)
        {
            return Utilities.IsNotNull(entityToUpdate)
                && elements.Any(t => t.Id == entityToUpdate.Id);
        }
    }
}