using Domain;
using Persistence;
using System;
using System.Collections.Generic;

namespace API.Services
{
    public class TransportServices : ITransportServices
    {
        internal IUnitOfWork Model { get; }
        internal ITransportRepository Transports { get; }

        public TransportServices()
        {
            Model = new UnitOfWork();
            Transports = Model.Transports;
        }

        public TransportServices(IUnitOfWork someUnitOfWork)
        {
            Model = someUnitOfWork;
            Transports = Model.Transports;
        }

        public int StartNewTransportFromData(string activeUsername,
            TransportDTO transportData)
        {
            User transporter = Model.Users.GetUserWithUsername(activeUsername);
            ICollection<Lot> lotsTransported = GetLotsFromNames(transportData.TransportedLotsNames);
            Transport transportToAdd = Transport.FromTransporterDateTimeLots(transporter,
                transportData.StartDateTime, lotsTransported);
            MarkLotsAndVehiclesAsModified(lotsTransported);
            Transports.AddNewTransport(transportToAdd);
            Model.SaveChanges();
            return transportToAdd.Id;
        }

        private ICollection<Lot> GetLotsFromNames(ICollection<string> transportedLotsNames)
        {
            var result = new List<Lot>();
            foreach (var name in transportedLotsNames)
            {
                var lotToAdd = Model.Lots.GetLotWithName(name);
                result.Add(lotToAdd);
            }
            return result;
        }

        public ICollection<TransportDTO> GetRegisteredTransports()
        {
            var result = new List<TransportDTO>();
            foreach (var transport in Transports.Elements)
            {
                result.Add(TransportDTO.FromTransport(transport));
            }
            return result.AsReadOnly();
        }

        public void FinalizeTransport(string activeUsername,
            int transportIdToFinalize, DateTime finalizationDateTime)
        {
            User transporter = Model.Users.GetUserWithUsername(activeUsername);
            Transport transportToFinalize = Model.Transports.GetTransportWithId(transportIdToFinalize);
            bool finalizerIsCreator = transporter.Equals(transportToFinalize.Transporter);
            if (finalizerIsCreator)
            {
                SetFinalizationData(finalizationDateTime, transportToFinalize);
            }
            else
            {
                throw new ServiceException(ErrorMessages.TransportFinalizerMustBeCreator);
            }
        }

        private void SetFinalizationData(DateTime finalizationDateTime, Transport transportToFinalize)
        {
            transportToFinalize.FinalizeTransportOnDate(finalizationDateTime);
            MarkLotsAndVehiclesAsModified(transportToFinalize.LotsTransported);
            Transports.UpdateTransport(transportToFinalize);
            Model.SaveChanges();
        }

        private void MarkLotsAndVehiclesAsModified(ICollection<Lot> lotsTransported)
        {
            foreach (var lot in lotsTransported)
            {
                Model.Lots.UpdateLot(lot);
                MarkVehiclesInLotAsModified(lot.Vehicles);
            }
        }

        private void MarkVehiclesInLotAsModified(ICollection<Vehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                Model.Vehicles.UpdateVehicle(vehicle);
            }
        }
    }
}