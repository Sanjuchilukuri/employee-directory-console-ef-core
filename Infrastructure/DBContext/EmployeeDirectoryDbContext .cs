using System.Configuration;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DBContext
{
    public class EmployeeDirectoryDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Job> Job { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Dept> Depts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId);

                entity.Property(e => e.EmpId)
                    .HasColumnType("varchar(6)");

                entity.Property(e => e.FirstName)
                    .IsRequired();

                entity.Property(e => e.LastName)
                    .IsRequired();

                entity.Property(e => e.Email)
                    .IsRequired();

                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.Property(e => e.DateofBirth)
                    .HasColumnType("Date");

                entity.Property(e => e.JoiningDate)
                    .HasColumnType("Date")
                    .IsRequired();

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("varchar(10)")
                    .IsRequired();

                entity.HasIndex(e => e.PhoneNumber)
                    .IsUnique();

                entity.HasOne(e => e.Job)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(e => e.JobId);

                entity.Property(e => e.JobId)
                    .IsRequired();

                entity.Property(e => e.Location)
                    .IsRequired();

            });

            modelBuilder.Entity<Job>(static entity =>
            {
                entity.HasKey(e => e.JobId);

                entity.Property(e => e.JobId)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn(seed: 1, increment: 1);

                entity.HasIndex(entity => entity.RoleId)
                    .IsUnique();

                entity.Property(e => e.RoleId)
                    .IsRequired();

                entity.HasOne(d => d.Role)
                    .WithOne(p => p.Job)
                    .HasForeignKey<Job>(d => d.RoleId);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(entity => entity.RoleId);

                entity.Property(entity => entity.RoleId)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn(seed: 1, increment: 1);

                entity.Property(entity => entity.DeptId)
                    .IsRequired();

                entity.Property(entity => entity.RoleName)
                    .IsRequired();

                entity.HasOne(d => d.Dept)
                    .WithMany(r => r.Roles)
                    .HasForeignKey(d => d.DeptId);

            });

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.HasKey(entity => entity.DeptId);

                entity.Property(entity => entity.DeptId)
                    .ValueGeneratedOnAdd()
                    .UseIdentityColumn(seed: 1, increment: 1);

                entity.Property(entity => entity.DeptName)
                    .IsRequired();

                entity.HasIndex(entity => entity.DeptName)
                    .IsUnique();
            });

            // modelBuilder.Entity<Role>().InsertUsingStoredProcedure(entity =>
            // {

            // });

        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added || e.State == EntityState.Modified
            ));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedBy = Environment.UserName;
                    ((BaseEntity)entityEntry.Entity).CreatedOn = DateOnly.FromDateTime(DateTime.Now);
                }

                if (entityEntry.State == EntityState.Modified)
                {
                    ((BaseEntity)entityEntry.Entity).ModifiedBy = Environment.UserName;
                    ((BaseEntity)entityEntry.Entity).ModifiedOn = DateOnly.FromDateTime(DateTime.Now);
                }
            }

            return base.SaveChanges();
        }
    }
}
