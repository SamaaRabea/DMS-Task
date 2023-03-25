using Microsoft.EntityFrameworkCore;

namespace Clinic.DAL;

public class DoctorRepo : GenericRepo<Doctor>, IDoctorRepo
{
    private readonly ClinicContext _context;
    public DoctorRepo(ClinicContext context) : base(context)
    {
        _context = context;
    }

    public List<Appointment> GetDoctorAppointMent(int id)
    {
        var today = DateTime.Today;

        return _context.Appointments.Include(a => a.Patient)
                .Where(a => a.DoctorId == id && a.Date == today)
                //.Include(a => a.Patient)
                .ToList();
    }
    public Doctor GetFirst(String name)
    {
        return _context.Doctors.FirstOrDefault(d => d.Name == name);
    } 

}

