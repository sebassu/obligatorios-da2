using System;
using System.Globalization;
using System.Collections.Generic;

namespace Domain
{
    public enum ProcessStages { PORT, TRANSPORT, YARD }

    public class ProcessData
    {
        public int Id { get; set; }

        public ProcessStages CurrentStage { get; set; } = ProcessStages.PORT;

        public Lot PortLot { get; set; }
        public Inspection PortInspection { get; set; }
        public Transport TransportData { get; set; }
        public Inspection YardInspection { get; set; }
        public ICollection<Movement> YardMovements { get; set; }
            = new List<Movement>();
        public Subzone YardCurrentLocation { get; set; }
        public DateTime? LastDateTimeToValidate { get; set; }

        public void RegisterPortLot(Lot value)
        {
            ValidateVehicleIsInStage(ProcessStages.PORT);
            PortLot = value;
        }

        internal void RegisterPortInspection(Inspection inspectionToSet)
        {
            ValidateVehicleIsInStage(ProcessStages.PORT);
            ValidatePropertyWasNotSetPreviously(PortInspection);
            bool isValidPortInspectionToSet = Utilities.IsNotNull(inspectionToSet) &&
                inspectionToSet.Location.Type == LocationType.PORT;
            if (isValidPortInspectionToSet)
            {
                PortInspection = inspectionToSet;
            }
            else
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.InvalidDataOnProcess, "Inspección de Puerto");
                throw new ProcessException(errorMessage);
            }
        }

        internal void SetTransportStartData(Transport transportToSet)
        {
            ValidateVehicleIsInStage(ProcessStages.PORT);
            bool isValidTransportData = Utilities.IsNotNull(transportToSet) &&
                transportToSet.LotsTransported.Contains(PortLot);
            if (isValidTransportData)
            {
                TransportData = transportToSet;
                CurrentStage = ProcessStages.TRANSPORT;
            }
            else
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.InvalidDataOnProcess, "Datos del transporte");
                throw new ProcessException(errorMessage);
            }
        }

        internal void SetTransportEndData()
        {
            ValidateVehicleIsInStage(ProcessStages.TRANSPORT);
            CurrentStage = ProcessStages.YARD;
            LastDateTimeToValidate = TransportData.EndDateTime;
        }

        internal void RegisterYardInspection(Inspection inspectionToSet)
        {
            ValidateVehicleIsInStage(ProcessStages.YARD);
            ValidatePropertyWasNotSetPreviously(YardInspection);
            bool isValidYardInspectionToSet = Utilities.IsNotNull(inspectionToSet)
                && inspectionToSet.Location.Type == LocationType.YARD;
            if (isValidYardInspectionToSet)
            {
                YardInspection = inspectionToSet;
            }
            else
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.InvalidDataOnProcess, "Inspección de Patio");
                throw new ProcessException(errorMessage);
            }
        }

        public Movement RegisterNewMovementToSubzone(User responsible,
            DateTime dateTimeOfMovement, Subzone destination)
        {
            ValidateVehicleIsInStage(ProcessStages.YARD);
            if (dateTimeOfMovement > LastDateTimeToValidate.GetValueOrDefault())
            {
                return AttemptToAddNewMovement(responsible, dateTimeOfMovement, destination);
            }
            else
            {
                throw new ProcessException(ErrorMessages.MovementDateIsInvalid);
            }
        }

        private Movement AttemptToAddNewMovement(User responsible,
            DateTime dateTimeOfMovement, Subzone destination)
        {
            Movement movementToAdd = Movement.CreateNewMovement(responsible,
                dateTimeOfMovement, YardCurrentLocation, destination);
            YardMovements.Add(movementToAdd);
            YardCurrentLocation = destination;
            LastDateTimeToValidate = dateTimeOfMovement;
            return movementToAdd;
        }

        internal bool IsReadyForTransport()
        {
            return CurrentStage == ProcessStages.PORT &&
                Utilities.IsNotNull(PortInspection);
        }

        private void ValidatePropertyWasNotSetPreviously(object propertyToValidate)
        {
            if (Utilities.IsNotNull(propertyToValidate))
            {
                throw new ProcessException(ErrorMessages.ProcessAlreadySetProperty);
            }
        }

        private void ValidateVehicleIsInStage(ProcessStages expectedStage)
        {
            if (CurrentStage != expectedStage)
            {
                throw new ProcessException(ErrorMessages.InvalidOperationOnVehicle);
            }
        }
    }
}