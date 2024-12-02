using Assesment.Data;
using Assesment.Interfaces;
using Assesment.ModelDto;
using Assesment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assesment.Respositories
{
    public class NurseRepository : INurseRepository
    {
        private readonly DataContext _context;
        public NurseRepository(DataContext context)
        {
            _context = context;
        }

        public bool CheckByName(string name)
        {
            return _context.Nurses.Any(n => n.Employee.Name.Equals(name));
        }

        public bool CreateNurse(Nurse nurse)
        {
            _context.Add(nurse);
            return save();
        }

        public bool DeleteNurse(Nurse nurse)
        {
           _context.Remove(nurse);
            return save();
        }

        public List<Nurse> GetAllNurses()
        {
            return _context.Nurses.Include(e => e.Employee).ToList();
        }


        public NurseDto GetNurseByEid(int Eid)
        {
            var  nurse = _context.Nurses.Where(n => n.EId == Eid).Include(e => e.Employee).Select(n => new NurseDto
            {
                Employee = new EmployeeDto
                {
                Name = n.Employee.Name,
                Address = n.Employee.Address,
                Salary = n.Employee.Salary

                }
            }).FirstOrDefault();

            return nurse;
        }

        public bool IsNurseExist(int EId)
        {
            return _context.Nurses.Any(n => n.EId == EId);
        }

        public bool save()
        {
           var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
