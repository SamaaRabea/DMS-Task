using Clinic.DAL;
namespace Clinic.BL
{
    public class PatientManager :IPatientManager
    {
        private readonly IPatientRepo _productRepo;

        public PatientManager (IPatientRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public Patient AddPatient(Patient patient)
        {
            _productRepo.Add(patient);
            _productRepo.SaveChanges();
            return patient;
        }

    }
}
