using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LeadManagementApi.Migrations
{
    public partial class Initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Suburb = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Date = table.Column<DateTime>(type: "dateTime2", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Desciption = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Status = table.Column<string>(type: "nvarchar(25)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leads", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leads");
        }
    }
}
