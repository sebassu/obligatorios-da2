using Domain;

namespace Persistence
{
    public interface IMovementRepository
    {
        void AddNewMovement(Movement movementToAdd);
    }
}
