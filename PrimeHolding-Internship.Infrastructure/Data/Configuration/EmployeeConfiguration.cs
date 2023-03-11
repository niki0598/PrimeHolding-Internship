using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PrimeHolding_Internship.Infrastructure.Data.Entities;

namespace PrimeHolding_Internship.Infrastructure.Data.Configuration
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(SeedEmployees());
        }

        private static List<Employee> SeedEmployees()
        {
            List<Employee> employees = new()
            {
                new Employee
                {
                    Id = 1,
                    FullName = "John Doe",
                    Email = "johndoe@yahoo.com",
                    BirthDate = new DateTime(1998, 5, 20),
                    PhoneNumber = "+35987651453",
                    Salary = 1800
                },
                new Employee
                {
                    Id = 2,
                    FullName = "Peter Jackson",
                    Email = "peterjackson@gmail.com",
                    BirthDate = new DateTime(1992, 12, 5),
                    PhoneNumber = "+359876578801",
                    Salary = 2500
                },
                new Employee
                {
                    Id = 3,
                    FullName = "Ivan Ivanov",
                    Email = "ivanivanov@abv.bg",
                    BirthDate = new DateTime(1994, 5, 10),
                    PhoneNumber = "+359876541801",
                    Salary = 1500
                },
                new Employee
                {
                    Id = 4,
                    FullName = "Petya Georgieva",
                    Email = "petya_g@yahoo.com",
                    BirthDate = new DateTime(2002, 1, 23),
                    PhoneNumber = "+359874528107",
                    Salary = 1650
                },
                new Employee
                {
                    Id = 5,
                    FullName = "Mariana Todorova",
                    Email = "mariana_todorova@abv.bg",
                    BirthDate = new DateTime(1993, 4, 25),
                    PhoneNumber = "+359876525809",
                    Salary = 2000
                },
                new Employee
                {
                    Id = 6,
                    FullName = "Georgi Georgiev",
                    Email = "george_g@yahoo.com",
                    BirthDate = new DateTime(1984, 12, 25),
                    PhoneNumber = "+359876575503",
                    Salary = 2800
                },
                new Employee
                {
                    Id = 7,
                    FullName = "Jane Doe",
                    Email = "janedoe@yahoo.com",
                    BirthDate = new DateTime(1995, 5, 27),
                    PhoneNumber = "+359875472800",
                    Salary = 1800
                },
            };

            return employees;
        }
    }
}
