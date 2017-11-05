using System.Linq;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
{
    internal class MovementRepository : GenericRepository<Movement>,
        IMovementRepository
    {
        public MovementRepository(VTSystemContext someContext)
            : base(someContext) { }

        public void AddNewMovement(Movement movementToAdd)
        {
            Add(movementToAdd);
        }

        public IEnumerable<Movement> Elements => GetElementsWith();

        public bool SubzoneParticipatesInSomeMovement(Subzone subzoneToVerify)
        {
            if (Utilities.IsNotNull(subzoneToVerify))
            {
                return elements.Any(m => (m.Departure != null
                    && m.Departure.Id == subzoneToVerify.Id) ||
                    (m.Arrival != null && m.Arrival.Id == subzoneToVerify.Id));
            }
            else
            {
                throw new RepositoryException(ErrorMessages.NullObjectRecieved);
            }
        }
    }
}