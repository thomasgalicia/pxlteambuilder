using Microsoft.EntityFrameworkCore.Migrations;

namespace PxlTeambuilderApi.Data.Migrations
{
    public partial class addrelationshipuserproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "Projects",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserEmail",
                table: "Projects",
                column: "UserEmail");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Users_UserEmail",
                table: "Projects",
                column: "UserEmail",
                principalTable: "Users",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Users_UserEmail",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Projects_UserEmail",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "Projects");
        }
    }
}
