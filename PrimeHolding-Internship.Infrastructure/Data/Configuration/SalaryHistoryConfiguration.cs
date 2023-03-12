using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using PrimeHolding_Internship.Infrastructure.Data.Entities;

namespace PrimeHolding_Internship.Infrastructure.Data.Configuration
{
    internal class SalaryHistoryConfiguration : IEntityTypeConfiguration<SalaryHistory>
    {
        public void Configure(EntityTypeBuilder<SalaryHistory> builder)
        {
            builder.HasData(SeedSalariesHistory());
        }

        private static List<SalaryHistory> SeedSalariesHistory()
        {
            List<SalaryHistory> employees = new()
            {
                new SalaryHistory
                {
                    Id = 1,
                    Salary = 1800,
                    EmployeeId = 1,
                    SalaryChangeDate = DateTime.Now,
                    Reason = "Initial salary"
                },
                new SalaryHistory
                {
                    Id = 2,
                    Salary = 2500,
                    EmployeeId = 2,
                    SalaryChangeDate = DateTime.Now,
                    Reason = "Initial salary"
                },
                new SalaryHistory
                {
                    Id = 3,
                    Salary = 1500,
                    EmployeeId = 3,
                    SalaryChangeDate = DateTime.Now,
                    Reason = "Initial salary"
                },
                new SalaryHistory
                {
                    Id = 4,
                    Salary = 1650,
                    EmployeeId = 4,
                    SalaryChangeDate = DateTime.Now,
                    Reason = "Initial salary"
                },
                new SalaryHistory
                {
                    Id = 5,
                    Salary = 2000,
                    EmployeeId = 5,
                    SalaryChangeDate = DateTime.Now,
                    Reason = "Initial salary"
                },
                new SalaryHistory
                {
                    Id = 6,
                    Salary = 2800,
                    EmployeeId = 6,
                    SalaryChangeDate = DateTime.Now,
                    Reason = "Initial salary"
                },
                new SalaryHistory
                {
                    Id = 7,
                    Salary = 1800,
                    EmployeeId = 7,
                    SalaryChangeDate = DateTime.Now,
                    Reason = "Initial salary"
                }
            };

            return employees;
        }
    }
}
