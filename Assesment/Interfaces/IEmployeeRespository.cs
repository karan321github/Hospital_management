using Assesment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assesment.Interfaces
{
    public interface IEmployeeRespository
    {
        public List<Employee> GetEmployees();
        public Employee GetEmployeeById(int id);
        public bool CreateEmplyee(Employee employee);
        public bool isEmployeeExist(int employeeId);
        public bool DeleteEmplyee(Employee employee);
        public bool save();

    }
}
