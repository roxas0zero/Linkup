using Microsoft.EntityFrameworkCore.Migrations;

namespace Linkup.Migrations
{
    public partial class addedInterestsAndFixedRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_ApplicationUsers_ApplicationUserEmail",
                table: "Skills");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Projects_ProjectId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_ApplicationUserEmail",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_ProjectId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "ApplicationUserEmail",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Skills");

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "ApplicationUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "ApplicationUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "ApplicationUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUserSkill",
                columns: table => new
                {
                    SkillsId = table.Column<int>(type: "int", nullable: false),
                    UsersEmail = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserSkill", x => new { x.SkillsId, x.UsersEmail });
                    table.ForeignKey(
                        name: "FK_ApplicationUserSkill_ApplicationUsers_UsersEmail",
                        column: x => x.UsersEmail,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserSkill_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSkill",
                columns: table => new
                {
                    NeededSkillsId = table.Column<int>(type: "int", nullable: false),
                    ProjectsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSkill", x => new { x.NeededSkillsId, x.ProjectsId });
                    table.ForeignKey(
                        name: "FK_ProjectSkill_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSkill_Skills_NeededSkillsId",
                        column: x => x.NeededSkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserInterest",
                columns: table => new
                {
                    InterestsId = table.Column<int>(type: "int", nullable: false),
                    UsersEmail = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserInterest", x => new { x.InterestsId, x.UsersEmail });
                    table.ForeignKey(
                        name: "FK_ApplicationUserInterest_ApplicationUsers_UsersEmail",
                        column: x => x.UsersEmail,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserInterest_Interests_InterestsId",
                        column: x => x.InterestsId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterestProject",
                columns: table => new
                {
                    ProjectsId = table.Column<int>(type: "int", nullable: false),
                    RelatedInterestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterestProject", x => new { x.ProjectsId, x.RelatedInterestsId });
                    table.ForeignKey(
                        name: "FK_InterestProject_Interests_RelatedInterestsId",
                        column: x => x.RelatedInterestsId,
                        principalTable: "Interests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InterestProject_Projects_ProjectsId",
                        column: x => x.ProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserInterest_UsersEmail",
                table: "ApplicationUserInterest",
                column: "UsersEmail");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserSkill_UsersEmail",
                table: "ApplicationUserSkill",
                column: "UsersEmail");

            migrationBuilder.CreateIndex(
                name: "IX_InterestProject_RelatedInterestsId",
                table: "InterestProject",
                column: "RelatedInterestsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkill_ProjectsId",
                table: "ProjectSkill",
                column: "ProjectsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserInterest");

            migrationBuilder.DropTable(
                name: "ApplicationUserSkill");

            migrationBuilder.DropTable(
                name: "InterestProject");

            migrationBuilder.DropTable(
                name: "ProjectSkill");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "Team",
                table: "ApplicationUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserEmail",
                table: "Skills",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ApplicationUserEmail",
                table: "Skills",
                column: "ApplicationUserEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_ProjectId",
                table: "Skills",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_ApplicationUsers_ApplicationUserEmail",
                table: "Skills",
                column: "ApplicationUserEmail",
                principalTable: "ApplicationUsers",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Projects_ProjectId",
                table: "Skills",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
