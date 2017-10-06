using System;
using System.Collections.Generic;
using Domain;
using System.Linq;
using System.Globalization;

namespace Persistence
{
    internal class SubzoneRepository : GenericRepository<Subzone>, ISubzoneRepository
    {
        public SubzoneRepository(VTSystemContext someContext) : base(someContext) { }

        public void AddNewSubzone(Subzone subzoneToAdd)
        {
            Add(subzoneToAdd);
        }

        public IEnumerable<Subzone> Elements => GetElementsThat();

        public Subzone GetSubzoneWithId(int idToFind)
        {
            try
            {
                return elements.Include("Container").Include("Vehicles")
                    .Single(s => s.Id == idToFind);
            }
            catch (InvalidOperationException)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.CouldNotFindField, "identificador de subzona", idToFind);
                throw new RepositoryException(errorMessage);
            }
        }

        public void UpdateSubzone(Subzone subzoneToModify)
        {
            Update(subzoneToModify);
        }

        public void RemoveSubzoneWithId(int idToRemove)
        {
            var userToRemove = GetSubzoneWithId(idToRemove);
            AttemptToRemove(userToRemove);
        }

        protected override bool ElementExistsInCollection(Subzone value)
        {
            return Utilities.IsNotNull(value) && elements.Any(z => z.Id == value.Id);
        }
    }
}