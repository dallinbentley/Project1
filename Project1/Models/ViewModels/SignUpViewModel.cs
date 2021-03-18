using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models.ViewModels
{
    //This loads in the available times as an Ienumarble and is able to store the dates that end up being selected.  We pass the timeId all the way through from this point in the program for deletion later on.
    public class SignUpViewModel
    {
        public IEnumerable<AvailableTimes> availableTimes { get; set; }
        public int TimeId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
    }
}
