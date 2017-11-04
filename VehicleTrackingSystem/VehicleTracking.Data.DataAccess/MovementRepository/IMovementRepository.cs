using Domain;
using System.Collections.Generic;

namespace Persistence
{
    public interface IMovementRepository
    {
        void AddNewMovement(Movement movementToAdd);
        IEnumerable<Movement> Elements { get; }
        bool SubzoneParticipatesInSomeMovement(Subzone subzoneToVerify);
    }
}