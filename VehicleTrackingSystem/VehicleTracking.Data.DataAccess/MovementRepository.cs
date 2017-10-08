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

        protected override bool ElementExistsInCollection(Movement entityToUpdate)
        {
            return Utilities.IsNotNull(entityToUpdate)
                && elements.Any(m => m.Id == entityToUpdate.Id);
        }
    }
}