using Clinic.DAL;

namespace Clinic.BL;

public class DoctorManager : IDoctorManager
{
    private readonly IDoctorRepo _doctorRepo;

    public DoctorManager(IDoctorRepo doctorRepo)
    {
        _doctorRepo = doctorRepo;
    }
    public Doctor AddDoctor(Doctor doctor)
    {
        _doctorRepo.Add(doctor);
        _doctorRepo.SaveChanges();
        return doctor;
    }

    public List<Appointment> GetAllDoctorAppointmentDay(int id)
    {
        var Appointments=_doctorRepo.GetDoctorAppointMent(id);
        return Appointments;
    }

    public List<Doctor> GetAllDoctors()
    {
        var dbDoctors = _doctorRepo.GetAll();
        return dbDoctors;
    }

    public Doctor? GetDoctorById(int id)
    {
        var dbDoctors = _doctorRepo.GetById(id);
        if (dbDoctors == null)
        {
            return null;
        }
        return dbDoctors;
    }
}

