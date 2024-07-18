using Infrastructure.DBContext;
using Infrastructure.DTO;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos
{
    public class EmployeeRepo : IEmployeeRepo
    {
        public string GetEmployeeSequenceID()
        {
            using (var context = new EmployeeDirectoryDbContext())
            {
                string? empID = context.Employees
                                      .OrderByDescending(emp => emp.EmpId)
                                      .Select(emp => emp.EmpId)
                                      .FirstOrDefault();

                return empID == null ? "TZ1000" : empID;
            }
        }

        public bool SaveEmployee(Employee newEmployee)
        {
            using (var context = new EmployeeDirectoryDbContext())
            {
                context.Employees.Add(newEmployee);

                if (context.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
        }

        public EmployeeDTO GetEmployeeById(string id)
        {
            using (var context = new EmployeeDirectoryDbContext())
            {
                var employee = context.Employees
                                      .Include(emp => emp.Job)
                                      .ThenInclude(job => job.Role)
                                      .ThenInclude(role => role.Dept)
                                      .Where(emp => emp.EmpId == id)
                                      .Select(employee => new EmployeeDTO()
                                      {
                                        EmpId = employee.EmpId,
                                        FirstName = employee.FirstName,
                                        LastName = employee.LastName,
                                        DateOfBirth = employee.DateofBirth.ToString(),
                                        PhoneNumber = employee.PhoneNumber,
                                        Email = employee.Email,
                                        JoiningDate = employee.JoiningDate.ToString(),
                                        Department = employee.Job.Role.Dept.DeptName,
                                        Role = employee.Job.Role.RoleName,
                                        Location = employee.Location,
                                        AssignManager = employee.AssignedManager,
                                        Project = employee.Project,
                                        JobId = employee.JobId
                                      });

                // Employee emp = context.Employees
                //                       .Include(emp => emp.Job)
                //                       .ThenInclude(job => job.Role)
                //                       .ThenInclude(role => role.Dept)
                //                       .Where(emp => emp.EmpId == id)
                //                       .FirstOrDefault()!;
                // Console.WriteLine(emp.Job.Role.RoleName);

                return employee.SingleOrDefault()!;
            }
        }

        public bool deleteEmployee(Employee employee)
        {
            using (var context = new EmployeeDirectoryDbContext())
            {
                context.Employees.Remove(employee);
                if (context.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
        }

        public List<EmployeeDTO> GetAllEmployees()
        {
            using (var context = new EmployeeDirectoryDbContext())
            {
                var employees = context.Employees
                                      .Include(emp => emp.Job)
                                      .ThenInclude(job => job.Role)
                                      .ThenInclude(role => role.Dept)
                                      .Select(employee => new EmployeeDTO()
                                      {
                                          EmpId = employee.EmpId,
                                          FirstName = employee.FirstName,
                                          LastName = employee.LastName,
                                          JoiningDate = employee.JoiningDate.ToString(),
                                          Department = employee.Job.Role.Dept.DeptName,
                                          Role = employee.Job.Role.RoleName,
                                          Location = employee.Location,
                                          AssignManager = employee.AssignedManager,
                                          Project = employee.Project
                                      }).ToList();

                // List<Employee> emps = context.Employees
                //                              .Include(emp => emp.Job)
                //                              .ThenInclude(job => job.Role)
                //                              .ThenInclude(role => role.Dept)
                //                              .ToList();

                return employees;
            }
        }


        public bool UpdateEmployee(Employee employee)
        {
            using (var context = new EmployeeDirectoryDbContext())
            {
                context.Update(employee);
                if (context.SaveChanges() > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}