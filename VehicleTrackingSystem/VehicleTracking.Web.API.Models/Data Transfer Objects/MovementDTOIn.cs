using System;
using System.ComponentModel.DataAnnotations;

namespace API.Services
{
    public class MovementDTOIn
    {
        public string ResponsibleUsername { get; set; }

        [Required]
        public int DepartureSubzoneId { get; set; }

        [Required]
        public int ArrivalSubzoneId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
    }
}