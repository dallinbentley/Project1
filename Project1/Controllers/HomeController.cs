using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    public class HomeController : Controller
    {
        private AppointmentContext context { get; set; }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AppointmentContext con)
        {
            _logger = logger;
            context = con;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View(new SignUpViewModel
            {
                availableTimes = context.AvailableTimes
            });
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel form)
        {
            ViewBag.Time = form.signUpTime.AvailableTime;
            return View("Form", new FormViewModel
            {
                formTime = form.signUpTime
            });
        }

        [HttpPost]
        public IActionResult FormPage(FormViewModel form)
        {
            if (ModelState.IsValid)
            {
                Appointment newAppointment = new Appointment();

                newAppointment.AppointmentTime = form.formTime.AvailableTime;
                newAppointment.GroupName = form.appointment.GroupName;
                newAppointment.GroupSize = form.appointment.GroupSize;
                newAppointment.Email = form.appointment.Email;
                newAppointment.Phone = form.appointment.Phone;

                context.Appointments.Add(newAppointment);

                context.AvailableTimes.Remove(context.AvailableTimes.Find(form.formTime.TimeId));

                context.SaveChanges();

                return View(context.Appointments);
            }
            else
            {
                return View();
            }
        }

        public IActionResult ViewAppointments()
        {
                return View(context.Appointments);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
