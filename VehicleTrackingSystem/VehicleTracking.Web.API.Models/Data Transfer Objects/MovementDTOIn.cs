using System;
using System.ComponentModel.DataAnnotations;

namespace API.Services
{
    [Serializable]
    public class MovementDTOIn
    {
        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int ArrivalSubzoneId { get; set; }
    }
}