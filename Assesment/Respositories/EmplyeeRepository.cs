using Assesment.Data;
using Assesment.Interfaces;
using Assesment.Models;

namespace Assesment.Respositories
{
    public class EmplyeeRepository : IEmployeeRespository
    {
        
        private DataContext _context;
        public EmplyeeRepository(DataContext context)
        {
            
            _context = context;


        }
        public bool CreateEmplyee(Employee employee)
        {
            _context.Add(employee);
            return save();
        }

        public bool DeleteEmplyee(Employee employee)
        {
            _context.Remove(employee);  
            return save();
        }

        public Employee GetEmployeeById(int id)
        {
           return _context.Employees.Where(e => e.EId == id).FirstOrDefault();
        }

        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public bool isEmployeeExist(int  id)
        {
           return _context.Employees.Any(e => e.EId == id);
        }

        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
