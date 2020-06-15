using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace team_test.Migrations
{
    public partial class RelationsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    QuestionGuid = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    IsRight = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionGuid",
                        column: x => x.QuestionGuid,
                        principalTable: "Questions",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Guid = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Guid);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestGuid",
                table: "Questions",
                column: "TestGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionGuid",
                table: "Answers",
                column: "QuestionGuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Tests_TestGuid",
                table: "Questions",
                column: "TestGuid",
                principalTable: "Tests",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Tests_TestGuid",
                table: "Questions");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropIndex(
                name: "IX_Questions_TestGuid",
                table: "Questions");
        }
    }
}
