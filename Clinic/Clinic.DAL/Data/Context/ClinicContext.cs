using Microsoft.EntityFrameworkCore;
namespace Clinic.DAL
{
    public class ClinicContext : DbContext
    {
        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options)
        {
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Clinics> Clinics { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<DayOfWeek> DayOfWeeks { get; set; }

    }
}
