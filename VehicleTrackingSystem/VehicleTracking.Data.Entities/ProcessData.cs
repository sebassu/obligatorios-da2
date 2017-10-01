namespace Domain
{
    public enum ProcessStages { PORT, TRANSPORT, YARD }

    public class ProcessData
    {
        public ProcessStages CurrentStage { get; set; } = ProcessStages.PORT;

        public Lot PortLot { get; set; }

        internal void RegisterPortLot(Lot value)
        {
            ValidateVehicleIsInStage(ProcessStages.PORT);
            bool isValidLotToSet = Utilities.IsNotNull(value);
            if (isValidLotToSet)
            {
                PortLot = value;
            }
            else
            {
                throw new ProcessException(ErrorMessages.NullDataOnProcess);
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