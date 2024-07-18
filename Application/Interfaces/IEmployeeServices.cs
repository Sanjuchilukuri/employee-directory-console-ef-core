using Infrastructure.DTO;
using Infrastructure.Models;

namespace Application.Interfaces
{
    public interface IEmployeeServices 
    {
        public bool AddEmployee(Employee emp);

        public bool DeleteEmployee(EmployeeDTO employee);

        public List<EmployeeDTO> GetEmployees();

        public EmployeeDTO GetEmployee(string id);

        bool UpdateEmployee(EmployeeDTO employee);
    }
}
