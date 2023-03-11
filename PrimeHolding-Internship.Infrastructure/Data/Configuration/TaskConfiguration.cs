using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Task = PrimeHolding_Internship.Infrastructure.Data.Entities.Task;

namespace PrimeHolding_Internship.Infrastructure.Data.Configuration
{
    internal class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasData(SeedTasks());
        }

        private static List<Task> SeedTasks()
        {

            List<Task> tasks = new()
            {
                new Task
                {
                    Id = 1,
                    Title = "Fixing bugs",
                    Description = "Fixing bugs related to the UX",
                    DueDate = new DateTime(2023, 5, 23, 12, 30, 00),
                    EmployeeId = 1
                },
                new Task
                {
                    Id = 2,
                    Title = "Implementing feature",
                    Description = "Implementing new feature related to the UI",
                    DueDate = new DateTime(2023, 3, 30, 17, 30, 00),
                    EmployeeId = 5
                },
                new Task
                {
                    Id = 3,
                    Title = "Learning new program language",
                    Description = "Learning JavaScript",
                    DueDate = new DateTime(2023, 4, 30, 19, 30, 00),
                    EmployeeId = 7
                },
                new Task
                {
                    Id = 4,
                    Title = "Testing code",
                    Description = "Testing code for bugs",
                    DueDate = new DateTime(2023, 8, 1, 20, 00, 00),
                    EmployeeId = 3
                },
                new Task
                {
                    Id = 5,
                    Title = "Building an application",
                    Description = "Building a new application",
                    DueDate = new DateTime(2023, 9, 10, 00, 00, 00),
                    EmployeeId = 6
                },
                new Task
                {
                    Id = 6,
                    Title = "Troubleshooting",
                    Description = "Troubleshooting",
                    DueDate = new DateTime(2023, 3, 20, 13, 30, 00),
                    EmployeeId = 5
                },
                new Task
                {
                    Id = 7,
                    Title = "Giving feedback",
                    Description = "Giving feedback to a junior developer",
                    DueDate = new DateTime(2023, 3, 15, 15, 00, 00),
                    EmployeeId = 1
                },
                new Task
                {
                    Id = 8,
                    Title = "Checking code",
                    Description = "Checking the code of an intern developer",
                    DueDate = new DateTime(2023, 4, 10, 10, 00, 00),
                    EmployeeId = 7
                },
                new Task
                {
                    Id = 9,
                    Title = "Writing documentation",
                    Description = "Writing documentation for the latest project",
                    DueDate = new DateTime(2023, 4, 1, 14, 30, 00),
                    EmployeeId = 4
                },
                new Task
                {
                    Id = 10,
                    Title = "Learning new stuff",
                    Description = "Learning the SOLID principles",
                    DueDate = new DateTime(2023, 5, 27, 17, 00, 00),
                    EmployeeId = 2
                }
            };

            return tasks;
        }
    }
}
