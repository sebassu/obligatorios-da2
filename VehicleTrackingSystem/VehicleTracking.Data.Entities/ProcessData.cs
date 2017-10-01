using System;
using System.Globalization;

namespace Domain
{
    public enum ProcessStages { PORT, TRANSPORT, YARD }

    public class ProcessData
    {
        public ProcessStages CurrentStage { get; set; } = ProcessStages.PORT;

        public Lot PortLot { get; set; }
        public Inspection PortInspection { get; set; }
        public DateTime TransportStart { get; set; }
        public User Transporter { get; set; }
        public DateTime TransportEnd { get; set; }
        public Inspection YardInspection { get; set; }

        public void RegisterPortLot(Lot value)
        {
            ValidateVehicleIsInStage(ProcessStages.PORT);
            bool isValidLotToSet = Utilities.IsNotNull(value);
            if (isValidLotToSet)
            {
                PortLot = value;
            }
            else
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.InvalidDataOnProcess, "Lote");
                throw new ProcessException(errorMessage);
            }
        }

        public void RegisterPortInspection(Inspection inspectionToSet)
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

        internal void SetTransportStartData(User transporterToSet)
        {
            CurrentStage = ProcessStages.TRANSPORT;
            TransportStart = DateTime.Now;
            Transporter = transporterToSet;
        }

        internal void SetTransportEndData()
        {
            CurrentStage = ProcessStages.YARD;
            TransportEnd = DateTime.Now;
        }

        public void RegisterYardInspection(Inspection inspectionToSet)
        {
            ValidateVehicleIsInStage(ProcessStages.YARD);
            ValidatePropertyWasNotSetPreviously(YardInspection);
            bool isValidYardInspectionToSet = Utilities.IsNotNull(inspectionToSet) &&
                inspectionToSet.Location.Type == LocationType.YARD;
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