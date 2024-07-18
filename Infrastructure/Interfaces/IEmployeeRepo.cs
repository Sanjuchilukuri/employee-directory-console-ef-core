
using Infrastructure.Models;
using Infrastructure.DTO;

namespace Infrastructure.Interfaces
{
    public interface IEmployeeRepo 
    {
        public string GetEmployeeSequenceID();

        public EmployeeDTO GetEmployeeById(string Id);

        public bool SaveEmployee(Employee newEmployee);

        public bool deleteEmployee(Employee employee);

        public List<EmployeeDTO> GetAllEmployees();
        
        bool UpdateEmployee(Employee employee);
    }
}