using Domain;
using System.Collections.Generic;

namespace Persistence
{
    public interface IInspectionRepository
    {
        void AddNewInspection(Inspection inspectionToAdd);
        IEnumerable<Inspection> Elements { get; }
        Inspection GetInspectionWithId(int idToLookup);
    }
}
