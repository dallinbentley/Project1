using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class AppointmentContext : DbContext
    {
        public AppointmentContext (DbContextOptions<AppointmentContext> options) : base(options)
        {

        }

        //We create two tables within this appointment context.

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AvailableTimes> AvailableTimes { get; set; }
    }
}
