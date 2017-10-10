using System;
using System.ComponentModel.DataAnnotations;

namespace API.Services
{
    public class MovementDTOIn
    {
        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int ArrivalSubzoneId { get; set; }
    }
}