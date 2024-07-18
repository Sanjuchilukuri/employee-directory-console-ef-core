using System.Linq.Expressions;
using Infrastructure.DBContext;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Infrastructure.Repos
{
    public class DepartmentsAndRolesRepo : IDepartmentsAndRolesRepo
    {
        public bool AddRole(string newRole, string department)
        {
            bool IsSuccessful = false;
            using (var context = new EmployeeDirectoryDbContext())
            {
                using var transaction = context.Database.BeginTransaction();
                transaction.CreateSavepoint("BeforeOperation");

                try
                {
                    int deptId = context.Depts.Where(dept => dept.DeptName == department).Select(selector => selector.DeptId).FirstOrDefault();

                    bool isRoleNotExists = !context.Roles.Any(role => role.DeptId == deptId && role.RoleName == newRole);

                    if (isRoleNotExists)
                    {
                        Role role = new Role
                        {
                            DeptId = deptId,
                            RoleName = newRole
                        };
                        context.Add(role);

                        if (context.SaveChanges() > 0)
                        {
                            Job job = new Job
                            {
                                RoleId = role.RoleId
                            };
                            context.Add(job);

                            if (context.SaveChanges() > 0)
                            {
                                IsSuccessful = true;
                            }
                        }
                    }
                    transaction.Commit();
                }
                catch(Exception)
                {
                    transaction.RollbackToSavepoint("BeforeOperation");
                }
            }
            return IsSuccessful;
        }


        public List<string> GetDepartments()
        {
            List<string> depts = new List<string>();
            using (var context = new EmployeeDirectoryDbContext())
            {
                depts = context.Depts.Select(selector => selector.DeptName).ToList();
            }
            return depts;
        }

        public List<string> GetAllRoles()
        {
            List<string> allRoles = new List<string>();
            using (var context = new EmployeeDirectoryDbContext())
            {
                allRoles = context.Roles.Select(selector => selector.RoleName).Distinct().ToList();
            }
            return allRoles;
        }

        public List<string> GetDeparmentRoles(string department)
        {
            List<string> departmentRoles;
            using (var context = new EmployeeDirectoryDbContext())
            {
                departmentRoles = context.Roles
                                         .Where(role => role.Dept.DeptName == department)
                                         .Select(role => role.RoleName)
                                         .ToList();
            }
            return departmentRoles;
        }


        public int GetJobId(string department, string role)
        {
            int jobId = 0;
            using (var context = new EmployeeDirectoryDbContext())
            {
                jobId = context.Job
                               .Where(jobs => jobs.Role.RoleName == role && jobs.Role.Dept.DeptName == department)
                               .Select(selector => selector.JobId)
                               .FirstOrDefault();
            }
            return jobId;
        }
    }
}