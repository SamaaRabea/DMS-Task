using Clinic.BL;
using Clinic.DAL;
using Microsoft.AspNetCore.Mvc;


namespace Clinic.Controllers
{
    public class DoctorController : Controller
    {
        private IDoctorManager _doctorManager;

        public DoctorController(IDoctorManager doctorManager)
        {
            _doctorManager = doctorManager;
        }
        public ActionResult<IEnumerable<Doctor>> Index()
        {
            IEnumerable<Doctor> objDoctortList = _doctorManager.GetAllDoctors();
            return View(objDoctortList);
           
        }
        public IActionResult DoctorAppointment(int id)
        {
            var _doctor = _doctorManager.GetDoctorById(id);
            var appointments = _doctorManager.GetAllDoctorAppointmentDay(id);
            // Pass the appointments and doctor to the view
            ViewBag.Doctor = _doctor;
            return View(appointments);

        }
    }
}
