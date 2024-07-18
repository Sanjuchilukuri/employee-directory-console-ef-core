namespace Infrastructure.Models
{
    public class Dept : BaseEntity
    {
        public int DeptId { get; set; }

        public string DeptName { get; set; } = null!;

        public ICollection<Role> Roles { get; set; } = new List<Role>();

    }
}
