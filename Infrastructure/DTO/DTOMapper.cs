using Infrastructure.Models;

namespace Infrastructure.DTO
{
    public static class Mapper
    {
        public static Employee MapEmployeeDTOToEmployee(EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
                return null!;

            return new Employee
            {
                EmpId = employeeDTO.EmpId!,
                FirstName = employeeDTO.FirstName!,
                LastName = employeeDTO.LastName!,
                Email = employeeDTO.Email!,
                DateofBirth = string.IsNullOrEmpty(employeeDTO.DateOfBirth) ? null : DateOnly.Parse(employeeDTO.DateOfBirth),
                JoiningDate = DateOnly.Parse(employeeDTO.JoiningDate!)!,
                PhoneNumber = employeeDTO.PhoneNumber,
                JobId = employeeDTO.JobId!,
                Location = employeeDTO.Location!,
                AssignedManager = employeeDTO.AssignManager,
                Project = employeeDTO.Project
            };
        }
    }
}
