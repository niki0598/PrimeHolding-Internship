using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeHolding_Internship.Infrastructure.Migrations
{
    public partial class RenamedAnEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskCompleted",
                table: "Employees",
                newName: "TasksCompleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TasksCompleted",
                table: "Employees",
                newName: "TaskCompleted");
        }
    }
}
