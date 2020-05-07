using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VroomAuto.DataAccess.Migrations
{
    public partial class InitialDataAccess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RegistrationNumber = table.Column<string>(nullable: true),
                    Km = table.Column<int>(nullable: false),
                    ManufacutreDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Class = table.Column<string>(nullable: true),
                    Price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    User = table.Column<string>(nullable: true),
                    Car = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UnwantedUsers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CNP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnwantedUsers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdentityID = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Adress = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    CNP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropTable(
                name: "UnwantedUsers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
