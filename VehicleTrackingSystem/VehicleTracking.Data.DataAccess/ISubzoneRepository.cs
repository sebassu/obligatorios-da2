using Domain;
using System.Collections.Generic;

namespace Persistence
{
    public interface ISubzoneRepository
    {
        void AddNewSubzone(Subzone subzoneToAdd);
        IEnumerable<Subzone> Elements { get; }
        void UpdateSubzone(Subzone subzoneToModify);
        void RemoveSubzoneWithId(int id);
    }
}
