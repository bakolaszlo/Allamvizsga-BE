using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataManager.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Performances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    UserAge = table.Column<string>(type: "text", nullable: false),
                    CalibrationGrade = table.Column<string>(type: "text", nullable: false),
                    TimeSpentToComplete = table.Column<int>(type: "integer", nullable: false),
                    Pin = table.Column<string>(type: "text", nullable: false),
                    ComplitionDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ScreenDisplaySize = table.Column<string>(type: "text", nullable: false),
                    DistanceBetweenDisplayAndUser = table.Column<string>(type: "text", nullable: false),
                    QOVision = table.Column<string>(type: "text", nullable: false),
                    LightSurrounding = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performances", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Performances");
        }
    }
}
