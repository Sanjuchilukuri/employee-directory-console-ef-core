using Application.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.DTO;
using Infrastructure.Models;

namespace Application.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeServices(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public bool AddEmployee(Employee newEmployee)
        {
            string empId = GenerateEmpID();
            if (!String.IsNullOrEmpty(empId))
            {
                newEmployee.EmpId = empId;
                return _employeeRepo.SaveEmployee(newEmployee);
            }
            else
            {
                return false;
            }
        }

        private string GenerateEmpID()
        {
            return "TZ" + (Convert.ToInt32(_employeeRepo.GetEmployeeSequenceID().Substring(2)) + 1).ToString();
        }

        public bool DeleteEmployee(EmployeeDTO employee)
        {
            return _employeeRepo.deleteEmployee(Mapper.MapEmployeeDTOToEmployee(employee));
        }

        public EmployeeDTO GetEmployee(string id)
        {
            return _employeeRepo.GetEmployeeById(id);
        }

        public List<EmployeeDTO> GetEmployees()
        {
            return _employeeRepo.GetAllEmployees();
        }

        public bool UpdateEmployee(EmployeeDTO employee)
        {
            return _employeeRepo.UpdateEmployee(Mapper.MapEmployeeDTOToEmployee(employee));
        }
    }
}