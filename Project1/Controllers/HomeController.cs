using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project1.Models;
using Project1.Models.ViewModels;
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
            //Set the viewbag for the page here as the date that was selected from the post.
            ViewBag.Time = form.Month.ToString() + "/" + form.Day.ToString() + "/" + form.Year.ToString() + " " + form.Hour.ToString() + ":00:00";
            return View("Form", new FormViewModel
            {
                TimeId = form.TimeId,
                Year = form.Year,
                Month = form.Month,
                Day = form.Day,
                Hour = form.Hour
            });
         }

        [HttpPost]
        public IActionResult FormPage(FormViewModel form)
        {
            //This is adding the appointment to the database and deleting the time.  We chose to delete the time for the simplicity of this assignment.  Since there are no CRUD requirements, we figured this would be faster and easier.
            if (ModelState.IsValid)
            {
                Appointment newAppointment = new Appointment();

                newAppointment.AppointmentTime = new System.DateTime(form.Year, form.Month, form.Day, form.Hour,0,0);
                newAppointment.GroupName = form.appointment.GroupName;
                newAppointment.GroupSize = form.appointment.GroupSize;
                newAppointment.Email = form.appointment.Email;
                newAppointment.Phone = form.appointment.Phone;

                context.Appointments.Add(newAppointment);

                context.AvailableTimes.Remove(context.AvailableTimes.Find(form.TimeId));

                context.SaveChanges();

                return View("Confirmation", new ConfirmationViewModel
                {
                    Year = newAppointment.AppointmentTime.Year,
                    Month = newAppointment.AppointmentTime.Month,
                    Hour = newAppointment.AppointmentTime.Hour,
                    Day = newAppointment.AppointmentTime.Day
                }) ;
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
