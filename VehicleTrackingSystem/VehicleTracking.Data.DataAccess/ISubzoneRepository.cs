using Domain;
using System.Collections.Generic;

namespace Persistence
{
    public interface ISubzoneRepository
    {
        void AddNewSubzone(Subzone subzoneToAdd);
        IEnumerable<Subzone> Elements { get; }
        Subzone GetSubzoneWithId(int idToFind);
        void UpdateSubzone(Subzone subzoneToModify);
        void RemoveSubzone(Subzone subzoneToRemove);
    }
}
