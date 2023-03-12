﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrimeHolding_Internship.Infrastructure.Data;

#nullable disable

namespace PrimeHolding_Internship.Infrastructure.Migrations
{
    [DbContext(typeof(AssignmentDbContext))]
    [Migration("20230312161648_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PrimeHolding_Internship.Infrastructure.Data.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("TasksCompleted")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1998, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "johndoe@yahoo.com",
                            FullName = "John Doe",
                            PhoneNumber = "+35987651453",
                            Salary = 1800m,
                            TasksCompleted = 0
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1992, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "peterjackson@gmail.com",
                            FullName = "Peter Jackson",
                            PhoneNumber = "+359876578801",
                            Salary = 2500m,
                            TasksCompleted = 0
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateTime(1994, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "ivanivanov@abv.bg",
                            FullName = "Ivan Ivanov",
                            PhoneNumber = "+359876541801",
                            Salary = 1500m,
                            TasksCompleted = 0
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateTime(2002, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "petya_g@yahoo.com",
                            FullName = "Petya Georgieva",
                            PhoneNumber = "+359874528107",
                            Salary = 1650m,
                            TasksCompleted = 0
                        },
                        new
                        {
                            Id = 5,
                            BirthDate = new DateTime(1993, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "mariana_todorova@abv.bg",
                            FullName = "Mariana Todorova",
                            PhoneNumber = "+359876525809",
                            Salary = 2000m,
                            TasksCompleted = 0
                        },
                        new
                        {
                            Id = 6,
                            BirthDate = new DateTime(1984, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "george_g@yahoo.com",
                            FullName = "Georgi Georgiev",
                            PhoneNumber = "+359876575503",
                            Salary = 2800m,
                            TasksCompleted = 0
                        },
                        new
                        {
                            Id = 7,
                            BirthDate = new DateTime(1995, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "janedoe@yahoo.com",
                            FullName = "Jane Doe",
                            PhoneNumber = "+359875472800",
                            Salary = 1800m,
                            TasksCompleted = 1
                        });
                });

            modelBuilder.Entity("PrimeHolding_Internship.Infrastructure.Data.Entities.SalaryHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("SalaryChangeDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("SalariesHistory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EmployeeId = 1,
                            Reason = "Initial salary",
                            Salary = 1800m,
                            SalaryChangeDate = new DateTime(2023, 3, 12, 18, 16, 48, 601, DateTimeKind.Local).AddTicks(7987)
                        },
                        new
                        {
                            Id = 2,
                            EmployeeId = 2,
                            Reason = "Initial salary",
                            Salary = 2500m,
                            SalaryChangeDate = new DateTime(2023, 3, 12, 18, 16, 48, 601, DateTimeKind.Local).AddTicks(8018)
                        },
                        new
                        {
                            Id = 3,
                            EmployeeId = 3,
                            Reason = "Initial salary",
                            Salary = 1500m,
                            SalaryChangeDate = new DateTime(2023, 3, 12, 18, 16, 48, 601, DateTimeKind.Local).AddTicks(8021)
                        },
                        new
                        {
                            Id = 4,
                            EmployeeId = 4,
                            Reason = "Initial salary",
                            Salary = 1650m,
                            SalaryChangeDate = new DateTime(2023, 3, 12, 18, 16, 48, 601, DateTimeKind.Local).AddTicks(8023)
                        },
                        new
                        {
                            Id = 5,
                            EmployeeId = 5,
                            Reason = "Initial salary",
                            Salary = 2000m,
                            SalaryChangeDate = new DateTime(2023, 3, 12, 18, 16, 48, 601, DateTimeKind.Local).AddTicks(8025)
                        },
                        new
                        {
                            Id = 6,
                            EmployeeId = 6,
                            Reason = "Initial salary",
                            Salary = 2800m,
                            SalaryChangeDate = new DateTime(2023, 3, 12, 18, 16, 48, 601, DateTimeKind.Local).AddTicks(8027)
                        },
                        new
                        {
                            Id = 7,
                            EmployeeId = 7,
                            Reason = "Initial salary",
                            Salary = 1800m,
                            SalaryChangeDate = new DateTime(2023, 3, 12, 18, 16, 48, 601, DateTimeKind.Local).AddTicks(8029)
                        });
                });

            modelBuilder.Entity("PrimeHolding_Internship.Infrastructure.Data.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DateCompleted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Fixing bugs related to the UX",
                            DueDate = new DateTime(2023, 5, 23, 12, 30, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 1,
                            IsCompleted = false,
                            Title = "Fixing bugs"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Implementing new feature related to the UI",
                            DueDate = new DateTime(2023, 3, 30, 17, 30, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 5,
                            IsCompleted = false,
                            Title = "Implementing feature"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Learning JavaScript",
                            DueDate = new DateTime(2023, 4, 30, 19, 30, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 7,
                            IsCompleted = false,
                            Title = "Learning new program language"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Testing code for bugs",
                            DueDate = new DateTime(2023, 8, 1, 20, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 3,
                            IsCompleted = false,
                            Title = "Testing code"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Building a new application",
                            DueDate = new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 6,
                            IsCompleted = false,
                            Title = "Building an application"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Troubleshooting",
                            DueDate = new DateTime(2023, 3, 20, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 5,
                            IsCompleted = false,
                            Title = "Troubleshooting"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Giving feedback to a junior developer",
                            DueDate = new DateTime(2023, 3, 15, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            IsCompleted = false,
                            Title = "Giving feedback"
                        },
                        new
                        {
                            Id = 8,
                            DateCompleted = new DateTime(2023, 3, 8, 12, 30, 0, 0, DateTimeKind.Unspecified),
                            Description = "Checking the code of an intern developer",
                            DueDate = new DateTime(2023, 4, 10, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 7,
                            IsCompleted = true,
                            Title = "Checking code"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Writing documentation for the latest project",
                            DueDate = new DateTime(2022, 4, 1, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 4,
                            IsCompleted = false,
                            Title = "Writing documentation"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Learning the SOLID principles",
                            DueDate = new DateTime(2023, 5, 27, 17, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 2,
                            IsCompleted = false,
                            Title = "Learning new stuff"
                        });
                });

            modelBuilder.Entity("PrimeHolding_Internship.Infrastructure.Data.Entities.SalaryHistory", b =>
                {
                    b.HasOne("PrimeHolding_Internship.Infrastructure.Data.Entities.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("PrimeHolding_Internship.Infrastructure.Data.Entities.Task", b =>
                {
                    b.HasOne("PrimeHolding_Internship.Infrastructure.Data.Entities.Employee", "Employee")
                        .WithMany("Tasks")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("PrimeHolding_Internship.Infrastructure.Data.Entities.Employee", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}