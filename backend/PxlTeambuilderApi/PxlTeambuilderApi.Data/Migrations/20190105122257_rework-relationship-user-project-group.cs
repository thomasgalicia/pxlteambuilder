using Microsoft.EntityFrameworkCore.Migrations;

namespace PxlTeambuilderApi.Data.Migrations
{
    public partial class reworkrelationshipuserprojectgroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Projects_ProjectId",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "UserGroups");

            migrationBuilder.DropTable(
                name: "UserProjects");

            migrationBuilder.CreateTable(
                name: "UserProjectDetails",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<string>(nullable: false),
                    GroupId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjectDetails", x => new { x.UserId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_UserProjectDetails_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProjectDetails_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProjectDetails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProjectDetails_GroupId",
                table: "UserProjectDetails",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjectDetails_ProjectId",
                table: "UserProjectDetails",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Projects_ProjectId",
                table: "Groups",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Projects_ProjectId",
                table: "Groups");

            migrationBuilder.DropTable(
                name: "UserProjectDetails");

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    GroupId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => new { x.UserId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_UserGroups_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "GroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroups_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProjects",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProjects", x => new { x.UserId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_UserProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProjects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserGroups_GroupId",
                table: "UserGroups",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjects_ProjectId",
                table: "UserProjects",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Projects_ProjectId",
                table: "Groups",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
