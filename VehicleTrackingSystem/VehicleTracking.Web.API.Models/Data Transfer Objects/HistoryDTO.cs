using System;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace API.Services
{
    [Serializable]
    public class HistoryDTO
    {
        public LotDTO LotData { get; private set; }
        public InspectionDTO PortInspectionData { get; private set; }
        public TransportDTO TransportData { get; private set; }
        public InspectionDTO YardInspectionData { get; private set; }
        public IEnumerable<MovementDTOOut> MovementsData { get; private set; }
        public SaleDTO SaleData { get; set; }

        internal static HistoryDTO FromFullyLoadedVehicle(Vehicle someVehicle)
        {
            return new HistoryDTO(someVehicle);
        }

        public HistoryDTO(Vehicle someVehicle)
        {
            SetPortData(someVehicle.PortLot, someVehicle.PortInspection);
            SetTransportData(someVehicle.TransportData);
            SetYardData(someVehicle.YardInspection, someVehicle.Movements);
            SaleData = Utilities.IsNull(someVehicle.SaleRecord) ? null :
                SaleDTO.FromSale(someVehicle.SaleRecord);
        }

        private void SetPortData(Lot portLot, Inspection portInspection)
        {
            LotData = Utilities.IsNull(portLot) ? null : LotDTO.FromLot(portLot);
            PortInspectionData = Utilities.IsNull(portInspection) ? null
                : InspectionDTO.FromInspection(portInspection);
        }

        private void SetTransportData(Transport transportData)
        {
            TransportData = Utilities.IsNull(transportData) ? null
                : TransportDTO.FromTransport(transportData);
        }

        private void SetYardData(Inspection yardInspection, ICollection<Movement> movements)
        {
            YardInspectionData = Utilities.IsNull(yardInspection) ? null
                : InspectionDTO.FromInspection(yardInspection);
            MovementsData = MovementDTOOut.FromMovements(movements);
        }
    }
}