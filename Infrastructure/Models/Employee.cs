
namespace Infrastructure.Models
{
    //[Table("Employee", Schema = "dbo")]
    //[Index(nameof(Email), IsUnique = true), Index(nameof(PhoneNumber), IsUnique = true)]
    public class Employee : BaseEntity
    {
        
        //[Key, Column(TypeName = "Varchar(6)")]
        public string EmpId { get; set; } = null!;

        //[Required]
        public string FirstName { get; set; } = null!;

        //[Required]
        public string LastName { get; set; } = null!;

        //[Required]
        public string Email { get; set; } = null!;

        //[Column(TypeName = "Date")]
        public DateOnly? DateofBirth { get; set; }

        //[Column(TypeName = "Date"), Required]
        public DateOnly JoiningDate { get; set; }

        //[Column(TypeName = "Varchar(10)")]
        public string? PhoneNumber { get; set; }

        //[ForeignKey("Job"), Required]
        public int JobId { get; set; }

        //[Required]
        public string Location { get; set; } = null!;

        public string? AssignedManager { get; set; }

        public string? Project { get; set; }

        public Job Job { get; set; } = null!;
    }
}
