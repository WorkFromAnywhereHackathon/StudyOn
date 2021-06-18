using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyOn.Server.Migrations
{
    public partial class AddTeamFeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeamFeedbacks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpertId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Problems = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ideas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Support = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamFeedbacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamFeedbacks_Experts_ExpertId",
                        column: x => x.ExpertId,
                        principalTable: "Experts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamFeedbacks_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamFeedbacks_ExpertId",
                table: "TeamFeedbacks",
                column: "ExpertId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamFeedbacks_TeamId",
                table: "TeamFeedbacks",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamFeedbacks");
        }
    }
}
