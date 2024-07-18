namespace Infrastructure.Models
{
    public class Role : BaseEntity
    {
        public int RoleId { get; set; }

        public int DeptId { get; set; }

        public string RoleName { get; set; } = null!;

        public Job Job { get; set; } = null!;

        public Dept Dept { get; set; } = null!;

    }
}
