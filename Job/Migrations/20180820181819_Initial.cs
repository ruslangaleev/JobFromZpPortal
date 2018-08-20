using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Job.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rubrics",
                columns: table => new
                {
                    RubricId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubrics", x => x.RubricId);
                });

            migrationBuilder.CreateTable(
                name: "Vacancies",
                columns: table => new
                {
                    VacancyId = table.Column<Guid>(nullable: false),
                    VersionId = table.Column<Guid>(nullable: false),
                    Salary = table.Column<string>(nullable: true),
                    PositionTitle = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Header = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacancies", x => x.VacancyId);
                });

            migrationBuilder.CreateTable(
                name: "VersionInfos",
                columns: table => new
                {
                    VersionInfoId = table.Column<Guid>(nullable: false),
                    UpdateAt = table.Column<DateTime>(nullable: false),
                    DataType = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    CountDownloded = table.Column<int>(nullable: false),
                    ErrorMessage = table.Column<string>(nullable: true),
                    IsDownloaded = table.Column<bool>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersionInfos", x => x.VersionInfoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rubrics");

            migrationBuilder.DropTable(
                name: "Vacancies");

            migrationBuilder.DropTable(
                name: "VersionInfos");
        }
    }
}
