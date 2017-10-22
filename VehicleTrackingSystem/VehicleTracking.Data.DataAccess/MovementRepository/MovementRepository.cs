using Domain;
using System.Linq;

namespace Persistence
{
    internal class MovementRepository : GenericRepository<Movement>, IMovementRepository
    {
        public MovementRepository(VTSystemContext someContext)
            : base(someContext) { }

        public void AddNewMovement(Movement movementToAdd)
        {
            Add(movementToAdd);
        }

        public bool SubzoneParticipatesInSomeMovement(Subzone subzoneToVerify)
        {
            return elements.Any(m => m.Departure.Id == subzoneToVerify.Id ||
                m.Arrival.Id == subzoneToVerify.Id);
        }

        protected override bool ElementExistsInCollection(Movement entityToUpdate)
        {
            return Utilities.IsNotNull(entityToUpdate)
                && elements.Any(m => m.Id == entityToUpdate.Id);
        }
    }
}