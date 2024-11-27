using Assesment.Data;
using Assesment.Interfaces;
using Assesment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Respositories
{
    public class PatientRepository : IPatientRepository
    {
        private DataContext _context;
        public PatientRepository(DataContext context) 
        { 
            _context = context;
        }

        public bool save()
        {
           var saved =_context.SaveChanges();
            return saved > 0 ? true : false;
        }

        bool IPatientRepository.CreatePatient(Patient patient)
        {
            _context.Add(patient);
            return save();
        }

        bool IPatientRepository.DeletePatient(Patient patient)
        {
            _context.Remove(patient);
            return save();
        }

        Patient IPatientRepository.GetPatient(int id)
        {
           return _context.Patients.Where(p => p.PId == id).FirstOrDefault();
        }

        ICollection<Patient> IPatientRepository.GetPatients()
        {
          return _context.Patients.ToList();
        }

        bool IPatientRepository.isPatientExist(int patientId)
        {
           return _context.Patients.Where(p => p.PId != patientId).Any();
        }


        bool IPatientRepository.UpdatePatient(Patient patient)
        {
           _context.Update(patient);
            return save();
        }
    }
}
