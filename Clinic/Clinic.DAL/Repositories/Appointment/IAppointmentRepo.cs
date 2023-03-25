namespace Clinic.DAL;

public interface IAppointmentRepo : IGenericRepo<Appointment>
{
    List<Appointment> GetAllAppointmentsWithPatientAndDoctor();
    Task<Appointment> CreateAppointment(Appointment appointment);
    Task<Appointment> GetFirst(DoctorAppointment model);
}

