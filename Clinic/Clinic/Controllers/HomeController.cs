using Clinic.BL;
using Clinic.DAL;
using Clinic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Controllers
{
    public class HomeController : Controller
    {
        private IAppointmentManager _appointmentManager;
        private IDoctorManager _doctorManager;

        public HomeController(IAppointmentManager appointmentManager,IDoctorManager doctorManager)
        {
            _appointmentManager = appointmentManager;
            _doctorManager = doctorManager;
        }

        public IActionResult Index()
        {
            var appointments = _appointmentManager.GetAllAppointmentsWithPatientAndDoctor();
            return View(appointments);
        }
        public IActionResult Create()
        {
            var doctors = _doctorManager.GetAllDoctors().ToList();
            ViewBag.Doctors=doctors;
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateAppointmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =await _appointmentManager.AddAppointmentAndPatient(model);
                if (result == false)
                {
                    ModelState.AddModelError("", "An appointment already exists at this date and time.");
                    return View(model);
                }if(result == true)
                {
                    return RedirectToAction("Index");
                }
            }

            // If model is not valid return the view with the validation errors
            return View(model);
        }
        public IActionResult Privacy()
        {
            return View();
        }

    }
}