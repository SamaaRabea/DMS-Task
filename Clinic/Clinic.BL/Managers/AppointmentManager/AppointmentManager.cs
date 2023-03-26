using Clinic.DAL;

namespace Clinic.BL;
public class AppointmentManager : IAppointmentManager
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPatientManager _patientManager;

    public AppointmentManager(IUnitOfWork unitOfWork,IPatientManager patientManager)
    {
        _unitOfWork = unitOfWork;
        _patientManager = patientManager;
    }
    public List<AppointmentViewModel> GetAllAppointmentsWithPatientAndDoctor()
    {
        var appointments = _unitOfWork.AppointmentRepo.GetAllAppointmentsWithPatientAndDoctor();

        return appointments.Select(a => new AppointmentViewModel
        {
            Date = a.Date,
            Time = a.Time,
            PatientName = a.Patient.Name,
            DoctorName = a.Doctor.Name,
        }).ToList();
    }

    public Appointment AddAppointment(Appointment appointment)
    {
        _unitOfWork.AppointmentRepo.Add(appointment);
        _unitOfWork.AppointmentRepo.SaveChanges();
        return appointment;
    }

    public async Task<bool> AddAppointmentAndPatient(CreateAppointmentViewModel model)
    {
        var doctor = _unitOfWork.DoctorRepo.GetFirst(model.DoctorName);
       if(doctor == null)
        {
            return false;
        }
        // Check if appointment already exists
        var existingAppointment = await _unitOfWork.AppointmentRepo.GetFirst(new DoctorAppointment { DoctorName = model.DoctorName, AppointmentDate = model.AppointmentDate, AppointmentTime = model.AppointmentTime });
        if (existingAppointment != null)
        {
            return false;
        }

        // Create a new Patient
        var patient = new Patient
        {
            Name = model.PatientName,
            BirthDate = model.PatientBirthDate,
            Phone = model.PatientPhone
        };
        _patientManager.AddPatient(patient);
        _unitOfWork.AppointmentRepo.SaveChanges();

        //var doctor = _unitOfWork.DoctorRepo.GetFirst(model.DoctorName);

        // Create a new Appointment
        var appointment = new Appointment
        {
            Date = model.AppointmentDate,
            Time = model.AppointmentTime,
            DoctorId = doctor.DoctorId,
            PatientId = patient.PatientId
        };
        this.AddAppointment(appointment);
        _unitOfWork.AppointmentRepo.SaveChanges();

        return true;

    }
}

