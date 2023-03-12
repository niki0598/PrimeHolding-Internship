using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeHolding_Internship.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TasksCompleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalariesHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salary = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    SalaryChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalariesHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalariesHistory_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "Email", "FullName", "PhoneNumber", "Salary", "TasksCompleted" },
                values: new object[,]
                {
                    { 1, new DateTime(1998, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe@yahoo.com", "John Doe", "+35987651453", 1800m, 0 },
                    { 2, new DateTime(1992, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "peterjackson@gmail.com", "Peter Jackson", "+359876578801", 2500m, 0 },
                    { 3, new DateTime(1994, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "ivanivanov@abv.bg", "Ivan Ivanov", "+359876541801", 1500m, 0 },
                    { 4, new DateTime(2002, 1, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "petya_g@yahoo.com", "Petya Georgieva", "+359874528107", 1650m, 0 },
                    { 5, new DateTime(1993, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "mariana_todorova@abv.bg", "Mariana Todorova", "+359876525809", 2000m, 0 },
                    { 6, new DateTime(1984, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "george_g@yahoo.com", "Georgi Georgiev", "+359876575503", 2800m, 0 },
                    { 7, new DateTime(1995, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "janedoe@yahoo.com", "Jane Doe", "+359875472800", 1800m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "DateCompleted", "Description", "DueDate", "EmployeeId", "IsCompleted", "Title" },
                values: new object[] { 7, null, "Giving feedback to a junior developer", new DateTime(2023, 3, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), null, false, "Giving feedback" });

            migrationBuilder.InsertData(
                table: "SalariesHistory",
                columns: new[] { "Id", "EmployeeId", "Reason", "Salary", "SalaryChangeDate" },
                values: new object[,]
                {
                    { 1, 1, "Initial salary", 1800m, new DateTime(2023, 3, 12, 18, 16, 48, 601, DateTimeKind.Local).AddTicks(7987) },
                    { 2, 2, "Initial salary", 2500m, new DateTime(2023, 3, 12, 18, 16, 48, 601, DateTimeKind.Local).AddTicks(8018) },
                    { 3, 3, "Initial salary", 1500m, new DateTime(2023, 3, 12, 18, 16, 48, 601, DateTimeKind.Local).AddTicks(8021) },
                    { 4, 4, "Initial salary", 1650m, new DateTime(2023, 3, 12, 18, 16, 48, 601, DateTimeKind.Local).AddTicks(8023) },
                    { 5, 5, "Initial salary", 2000m, new DateTime(2023, 3, 12, 18, 16, 48, 601, DateTimeKind.Local).AddTicks(8025) },
                    { 6, 6, "Initial salary", 2800m, new DateTime(2023, 3, 12, 18, 16, 48, 601, DateTimeKind.Local).AddTicks(8027) },
                    { 7, 7, "Initial salary", 1800m, new DateTime(2023, 3, 12, 18, 16, 48, 601, DateTimeKind.Local).AddTicks(8029) }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "DateCompleted", "Description", "DueDate", "EmployeeId", "IsCompleted", "Title" },
                values: new object[,]
                {
                    { 1, null, "Fixing bugs related to the UX", new DateTime(2023, 5, 23, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, false, "Fixing bugs" },
                    { 2, null, "Implementing new feature related to the UI", new DateTime(2023, 3, 30, 17, 30, 0, 0, DateTimeKind.Unspecified), 5, false, "Implementing feature" },
                    { 3, null, "Learning JavaScript", new DateTime(2023, 4, 30, 19, 30, 0, 0, DateTimeKind.Unspecified), 7, false, "Learning new program language" },
                    { 4, null, "Testing code for bugs", new DateTime(2023, 8, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), 3, false, "Testing code" },
                    { 5, null, "Building a new application", new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, false, "Building an application" },
                    { 6, null, "Troubleshooting", new DateTime(2023, 3, 20, 13, 30, 0, 0, DateTimeKind.Unspecified), 5, false, "Troubleshooting" },
                    { 8, new DateTime(2023, 3, 8, 12, 30, 0, 0, DateTimeKind.Unspecified), "Checking the code of an intern developer", new DateTime(2023, 4, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), 7, true, "Checking code" },
                    { 9, null, "Writing documentation for the latest project", new DateTime(2022, 4, 1, 14, 30, 0, 0, DateTimeKind.Unspecified), 4, false, "Writing documentation" },
                    { 10, null, "Learning the SOLID principles", new DateTime(2023, 5, 27, 17, 0, 0, 0, DateTimeKind.Unspecified), 2, false, "Learning new stuff" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalariesHistory_EmployeeId",
                table: "SalariesHistory",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_EmployeeId",
                table: "Tasks",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalariesHistory");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
