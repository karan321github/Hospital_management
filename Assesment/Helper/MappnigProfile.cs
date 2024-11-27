using Assesment.ModelDto;
using Assesment.Models;
using AutoMapper;

namespace Assesment.Helper
{
    public class MappnigProfile : Profile
    {
        public MappnigProfile()
        {
            CreateMap<Patient, PatientDto>();
            CreateMap<PatientDto, Patient>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Doctor, DoctorDto>();
            CreateMap<DoctorDto, Doctor>();
        }
    }
}
