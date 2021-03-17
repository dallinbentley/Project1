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

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult SignUp(Appointment appointment)
        {
            return View("Form", appointment);
        }
        public IActionResult ViewAppointments()
        {
            return View();
        }
        [HttpGet] IActionResult SignUp()
        {
            return View(context.AvailableTimes);
        }

        [HttpPost]
        public IActionResult SignUp(Appointment a)
        {
            if (ModelState.IsValid)
            {
                context.Appointments.Add(a);
                context.SaveChanges();
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
