using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
{
    public interface IMovementRepository
    {
        void AddNewMovement(Movement movementToAdd);
        IEnumerable<Movement> Elements { get; }
        bool SubzoneParticipatesInSomeMovement(Subzone subzoneToVerify);
    }
}