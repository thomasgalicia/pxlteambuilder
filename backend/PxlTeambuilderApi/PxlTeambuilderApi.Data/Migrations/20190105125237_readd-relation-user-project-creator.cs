using Microsoft.EntityFrameworkCore.Migrations;

namespace PxlTeambuilderApi.Data.Migrations
{
    public partial class readdrelationuserprojectcreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProjectDetails_Projects_ProjectId",
                table: "UserProjectDetails");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Projects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjectDetails_Projects_ProjectId",
                table: "UserProjectDetails",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_UserId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProjectDetails_Projects_ProjectId",
                table: "UserProjectDetails");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UserId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Projects");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjectDetails_Projects_ProjectId",
                table: "UserProjectDetails",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
