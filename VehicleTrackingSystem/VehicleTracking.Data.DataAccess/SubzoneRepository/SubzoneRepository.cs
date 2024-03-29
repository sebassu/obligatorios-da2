﻿using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
{
    internal class SubzoneRepository : GenericRepository<Subzone>, ISubzoneRepository
    {
        public SubzoneRepository(VTSystemContext someContext) : base(someContext) { }

        public void AddNewSubzone(Subzone subzoneToAdd)
        {
            Add(subzoneToAdd);
        }

        public IEnumerable<Subzone> Elements => GetElementsWith("Container");

        public Subzone GetSubzoneWithId(int idToFind)
        {
            try
            {
                return elements.Include("Container.Subzones").Include("Vehicles")
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

        public void RemoveSubzone(Subzone subzoneToRemove)
        {
            AttemptToRemove(subzoneToRemove);
        }

        internal override bool ElementExistsInCollection(Subzone value)
        {
            return Utilities.IsNotNull(value) && elements.Any(z => z.Id == value.Id);
        }
    }
}