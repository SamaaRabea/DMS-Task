using Clinic.DAL;

namespace Clinic.BL;

public interface IDoctorManager
{
    public List<Doctor> GetAllDoctors();
    Doctor? GetDoctorById(int id);
    Doctor AddDoctor(Doctor doctor);
    List<Appointment> GetAllDoctorAppointmentDay(int id);
}

