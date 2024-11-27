using Assesment.Data;
using Assesment.Interfaces;
using Assesment.ModelDto;
using Assesment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Respositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private DataContext _context;
        public DoctorRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateDoctor(Doctor doctor)
        {
            _context.Add(doctor);
            return save();
        }

        public bool DeleteDoctor(int id)
        {
            _context.Remove(id);
            return save();
        }

        public Doctor GetDoctor(int id)
        {
           
            return _context.Doctors.Where(d => d.id == id).Include(c => c.Employee).FirstOrDefault();
        }

        public List<Doctor> GetDoctors()
        {
            var doctors = _context.Doctors.Include(c => c.Employee);
            return doctors.ToList();
        }

        public bool isDoctorExist(int id)
        {
            return _context.Doctors.Any(d => d.id == id);
        }

        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateDoctor(Doctor doctor)
        {
            _context.Update(doctor);
            return save();
        }
    }
}
