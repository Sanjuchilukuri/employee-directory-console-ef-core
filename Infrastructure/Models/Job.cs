
namespace Infrastructure.Models
{
    public class Job : BaseEntity
    {

        public int JobId { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; } = null!;

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
