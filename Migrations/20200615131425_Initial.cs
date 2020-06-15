using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace team_test.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    TestGuid = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    QuestionType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Guid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Questions");
        }
    }
}
