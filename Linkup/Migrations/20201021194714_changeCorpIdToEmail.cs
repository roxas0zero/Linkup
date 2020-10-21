using Microsoft.EntityFrameworkCore.Migrations;

namespace Linkup.Migrations
{
    public partial class changeCorpIdToEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserProject_ApplicationUsers_ParticipantsCorpId",
                table: "ApplicationUserProject");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_ApplicationUsers_ApplicationUserCorpId",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUsers",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "CorpId",
                table: "ApplicationUsers");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserCorpId",
                table: "Skills",
                newName: "ApplicationUserEmail");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_ApplicationUserCorpId",
                table: "Skills",
                newName: "IX_Skills_ApplicationUserEmail");

            migrationBuilder.RenameColumn(
                name: "ParticipantsCorpId",
                table: "ApplicationUserProject",
                newName: "ParticipantsEmail");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ApplicationUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUsers",
                table: "ApplicationUsers",
                column: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserProject_ApplicationUsers_ParticipantsEmail",
                table: "ApplicationUserProject",
                column: "ParticipantsEmail",
                principalTable: "ApplicationUsers",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_ApplicationUsers_ApplicationUserEmail",
                table: "Skills",
                column: "ApplicationUserEmail",
                principalTable: "ApplicationUsers",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserProject_ApplicationUsers_ParticipantsEmail",
                table: "ApplicationUserProject");

            migrationBuilder.DropForeignKey(
                name: "FK_Skills_ApplicationUsers_ApplicationUserEmail",
                table: "Skills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUsers",
                table: "ApplicationUsers");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserEmail",
                table: "Skills",
                newName: "ApplicationUserCorpId");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_ApplicationUserEmail",
                table: "Skills",
                newName: "IX_Skills_ApplicationUserCorpId");

            migrationBuilder.RenameColumn(
                name: "ParticipantsEmail",
                table: "ApplicationUserProject",
                newName: "ParticipantsCorpId");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "ApplicationUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "CorpId",
                table: "ApplicationUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUsers",
                table: "ApplicationUsers",
                column: "CorpId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserProject_ApplicationUsers_ParticipantsCorpId",
                table: "ApplicationUserProject",
                column: "ParticipantsCorpId",
                principalTable: "ApplicationUsers",
                principalColumn: "CorpId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_ApplicationUsers_ApplicationUserCorpId",
                table: "Skills",
                column: "ApplicationUserCorpId",
                principalTable: "ApplicationUsers",
                principalColumn: "CorpId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
