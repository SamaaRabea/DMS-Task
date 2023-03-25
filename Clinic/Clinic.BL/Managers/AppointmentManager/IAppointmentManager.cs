using Clinic.DAL;

namespace Clinic.BL;

public interface IAppointmentManager
{
    List<AppointmentViewModel> GetAllAppointmentsWithPatientAndDoctor();
    public Appointment AddAppointment(Appointment appointment);
    public Task<bool> AddAppointmentAndPatient(CreateAppointmentViewModel model);


}

