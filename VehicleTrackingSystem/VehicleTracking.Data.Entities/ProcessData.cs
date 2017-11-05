using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;

namespace VehicleTracking_Data_Entities
{
    public enum ProcessStages
    {
        STUCK_IN_PROCESS, PORT, TRANSPORT,
        YARD, READY_FOR_SALE, SOLD
    }

    public class ProcessData
    {
        private const ushort portInspectionPosition = 0;
        private const ushort yardInspectionPosition = 1;

        public int Id { get; set; }

        public ProcessStages CurrentStage { get; set; } = ProcessStages.PORT;

        private IList<Inspection> inspections = new List<Inspection>();
        public IList<Inspection> Inspections
        {
            get { return inspections; }
            set
            {
                if (Utilities.IsNotNull(value))
                {
                    inspections = value;
                    SortInspectionsByDate();
                }
                else
                {
                    throw new ProcessException(ErrorMessages.InspectionCollectionIsNull);
                }
            }
        }

        private void SortInspectionsByDate()
        {
            inspections = inspections.OrderBy(i => i.DateTime).ToList();
        }

        public Lot PortLot { get; set; }

        public Inspection PortInspection
        {
            get
            {
                return Inspections.ElementAtOrDefault(portInspectionPosition);
            }
        }

        public Transport TransportData { get; set; }

        public Inspection YardInspection
        {
            get
            {
                return Inspections.ElementAtOrDefault(yardInspectionPosition);
            }
        }

        public ICollection<Movement> YardMovements { get; set; }
            = new List<Movement>();

        public Subzone YardCurrentLocation { get; set; }

        public Sale SaleRecord { get; set; }

        public DateTime? LastDateTimeToValidate { get; set; }

        public void RegisterPortLot(Lot value)
        {
            ValidateVehicleIsInStage(ProcessStages.PORT);
            PortLot = value;
        }

        internal void RegisterPortInspection(Inspection inspectionToAdd)
        {
            ValidateVehicleIsInStage(ProcessStages.PORT);
            ValidatePropertyWasNotSetPreviously(PortInspection);
            ValidateLengthOfInspectionListIs(0);
            AttemptToAddPortInspectionToInspectionsCollection(inspectionToAdd);
        }

        private void AttemptToAddPortInspectionToInspectionsCollection(Inspection inspectionToAdd)
        {
            bool isValidPortInspectionToSet = Utilities.IsNotNull(inspectionToAdd) &&
                inspectionToAdd.Location.Type == LocationType.PORT;
            if (isValidPortInspectionToSet)
            {
                inspections.Add(inspectionToAdd);
                SortInspectionsByDate();
            }
            else
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.InvalidInspectionData, "de Puerto");
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
                throw new ProcessException(ErrorMessages.InvalidTransportData);
            }
        }

        internal void SetTransportEndData()
        {
            ValidateVehicleIsInStage(ProcessStages.TRANSPORT);
            CurrentStage = ProcessStages.YARD;
            LastDateTimeToValidate = TransportData.EndDateTime;
        }

        internal void RegisterYardInspection(Inspection inspectionToAdd)
        {
            ValidateVehicleIsInStage(ProcessStages.YARD);
            ValidatePropertyWasNotSetPreviously(YardInspection);
            ValidateLengthOfInspectionListIs(1);
            AttemptToAddYardInspectionToInspectionsCollection(inspectionToAdd);
        }

        private void ValidateLengthOfInspectionListIs(int expectedLength)
        {
            if (inspections.Count != expectedLength)
            {
                throw new ProcessException(ErrorMessages.InvalidLengthOfInspectionCollection);
            }
        }

        private void AttemptToAddYardInspectionToInspectionsCollection(Inspection inspectionToAdd)
        {
            bool isValidYardInspectionToSet = Utilities.IsNotNull(inspectionToAdd)
                && inspectionToAdd.Location.Type == LocationType.YARD;
            if (isValidYardInspectionToSet)
            {
                ValidateDateOfActionIsCoherent(inspectionToAdd.DateTime);
                inspections.Add(inspectionToAdd);
                SortInspectionsByDate();
            }
            else
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.InvalidInspectionData, "de Patio");
                throw new ProcessException(errorMessage);
            }
        }

        public Movement RegisterNewMovementToSubzone(User responsible,
            DateTime dateTimeOfMovement, Subzone destination)
        {
            ValidateVehicleIsInStage(ProcessStages.YARD);
            ValidateVehicleWasInspectedInYard();
            ValidateDateOfActionIsCoherent(dateTimeOfMovement);
            return AttemptToAddNewMovement(responsible, dateTimeOfMovement, destination);
        }

        private void ValidateVehicleWasInspectedInYard()
        {
            if (Utilities.IsNull(YardInspection))
            {
                throw new ProcessException(ErrorMessages.YardInspectionRequiredBeforeMovement);
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

        internal void RegisterVehicleSale(Sale associatedSale)
        {
            ValidatePropertyWasNotSetPreviously(SaleRecord);
            ValidateVehicleIsInStage(ProcessStages.READY_FOR_SALE);
            ValidateDateOfActionIsCoherent(associatedSale.DateTime);
            SaleRecord = associatedSale;
            CurrentStage = ProcessStages.SOLD;
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

        private void ValidateDateOfActionIsCoherent(DateTime dateTimeOfMovement)
        {
            if (dateTimeOfMovement <= LastDateTimeToValidate.GetValueOrDefault())
            {
                var culture = CultureInfo.CurrentCulture;
                string errorMessage = string.Format(culture,
                    ErrorMessages.DateTimeForActionIsInvalid, LastDateTimeToValidate
                    .Value.ToString(culture));
                throw new ProcessException(errorMessage);
            }
        }
    }
}