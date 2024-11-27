using Assesment.Models;

namespace Assesment.Interfaces
{
    public interface IDoctorRepository
    {
        public Doctor GetDoctor(int id);
        public List<Doctor> GetDoctors();
        public bool isDoctorExist(int id);
        public bool CreateDoctor(Doctor doctor);    
        public bool DeleteDoctor(int id);
        public bool UpdateDoctor(Doctor doctor);

        public bool save();
    }
}
