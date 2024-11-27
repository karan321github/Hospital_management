using Assesment.Models;

namespace Assesment.Interfaces
{
    public interface IPatientRepository
    {
        ICollection<Patient>GetPatients();
        Patient GetPatient(int id);
        bool CreatePatient(Patient patient); 
        bool UpdatePatient(Patient patient);     
        bool DeletePatient(Patient patient);
        bool isPatientExist(int patientId);   
        bool save();

    }
}
