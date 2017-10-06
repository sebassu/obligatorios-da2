using Domain;
using System.Collections.Generic;

namespace Persistence
{
    public interface ISubzoneRepository
    {
        IEnumerable<Subzone> Elements { get; }
        void AddNewSubzone(Subzone subzoneToAdd);
        void UpdateSubzone(Subzone subzoneToModify);
        void RemoveSubzoneWithId(int id);
    }
}
