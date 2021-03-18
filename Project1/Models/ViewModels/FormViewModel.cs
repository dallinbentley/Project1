using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models.ViewModels
{
    //This model is so that we can pass the information about the date selected from the sign up page to the controller and to the view.  The form is submitted to the appointment class.
    public class FormViewModel
    {
        public int TimeId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public Appointment appointment { get; set; }
    }
}
