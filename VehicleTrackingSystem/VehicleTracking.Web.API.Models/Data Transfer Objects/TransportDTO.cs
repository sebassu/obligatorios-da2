using System;
using System.Linq;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Services
{
    [Serializable]
    public class TransportDTO
    {
        public int Id { get; set; }

        public string TransporterUsername { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        public ICollection<string> TransportedLotsNames { get; set; }

        public DateTime? EndDateTime { get; set; }

        internal TransportDTO() { }

        internal static TransportDTO FromTransport(Transport someTransport)
        {
            return new TransportDTO(someTransport);
        }

        internal TransportDTO(Transport someTransport)
        {
            Id = someTransport.Id;
            TransporterUsername = someTransport.Transporter.Username;
            StartDateTime = someTransport.StartDateTime.Value;
            TransportedLotsNames = someTransport.LotsTransported
                .Select(l => l.ToString()).ToList();
            EndDateTime = someTransport.EndDateTime;
        }
    }
}