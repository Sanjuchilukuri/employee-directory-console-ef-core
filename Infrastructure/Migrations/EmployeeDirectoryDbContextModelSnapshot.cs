﻿// <auto-generated />
using System;
using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(EmployeeDirectoryDbContext))]
    partial class EmployeeDirectoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Models.Dept", b =>
                {
                    b.Property<int>("DeptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeptId"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("CreatedOn")
                        .HasColumnType("date");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("ModifiedOn")
                        .HasColumnType("date");

                    b.HasKey("DeptId");

                    b.HasIndex("DeptName")
                        .IsUnique();

                    b.ToTable("Depts", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Employee", b =>
                {
                    b.Property<string>("EmpId")
                        .HasColumnType("varchar(6)");

                    b.Property<string>("AssignedManager")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("CreatedOn")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DateofBirth")
                        .HasColumnType("Date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("JoiningDate")
                        .HasColumnType("Date");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("ModifiedOn")
                        .HasColumnType("date");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Project")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("JobId");

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Job", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("CreatedOn")
                        .HasColumnType("date");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("ModifiedOn")
                        .HasColumnType("date");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("JobId");

                    b.HasIndex("RoleId")
                        .IsUnique();

                    b.ToTable("Job", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("CreatedOn")
                        .HasColumnType("date");

                    b.Property<int>("DeptId")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("ModifiedOn")
                        .HasColumnType("date");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.HasIndex("DeptId");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("Infrastructure.Models.Employee", b =>
                {
                    b.HasOne("Infrastructure.Models.Job", "Job")
                        .WithMany("Employees")
                        .HasForeignKey("JobId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Job");
                });

            modelBuilder.Entity("Infrastructure.Models.Job", b =>
                {
                    b.HasOne("Infrastructure.Models.Role", "Role")
                        .WithOne("Job")
                        .HasForeignKey("Infrastructure.Models.Job", "RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Infrastructure.Models.Role", b =>
                {
                    b.HasOne("Infrastructure.Models.Dept", "Dept")
                        .WithMany("Roles")
                        .HasForeignKey("DeptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dept");
                });

            modelBuilder.Entity("Infrastructure.Models.Dept", b =>
                {
                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Infrastructure.Models.Job", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("Infrastructure.Models.Role", b =>
                {
                    b.Navigation("Job")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}