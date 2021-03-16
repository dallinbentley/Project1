using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class Appointment
    {
        [Key]
        [Required]
        public int AppointmentId { get; set; }
        [Required]
        public DateTime AppointmentTime { get; set; }

        [Required]
        public string GroupName { get; set; }

        [Required]
        public int GroupSize { get; set; }

        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
