using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class AvailableTimes
    {
        [Key]
        [Required]
        public int TimeId { get; set; }
        [Required]
        public DateTime AvailableTime { get; set; }
    }
}
