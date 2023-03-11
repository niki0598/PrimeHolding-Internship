using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeHolding_Internship.Infrastructure.Migrations
{
    public partial class TaskTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCompleted",
                table: "Tasks",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCompleted",
                table: "Tasks");
        }
    }
}
