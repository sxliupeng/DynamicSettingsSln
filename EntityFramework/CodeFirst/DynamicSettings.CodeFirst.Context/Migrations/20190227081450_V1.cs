using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DynamicSettings.CodeFirst.Context.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblGroups",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateModified = table.Column<DateTimeOffset>(nullable: true),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblGroups", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TblRights",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateModified = table.Column<DateTimeOffset>(nullable: true),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRights", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TblRoles",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateModified = table.Column<DateTimeOffset>(nullable: true),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRoles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TblUsers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateModified = table.Column<DateTimeOffset>(nullable: true),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUsers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TblGroupRights",
                columns: table => new
                {
                    GroupID = table.Column<Guid>(nullable: false),
                    RightID = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateModified = table.Column<DateTimeOffset>(nullable: true),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblGroupRights", x => new { x.GroupID, x.RightID });
                    table.ForeignKey(
                        name: "FK_TblGroupRights_TblGroups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "TblGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblGroupRights_TblRights_RightID",
                        column: x => x.RightID,
                        principalTable: "TblRights",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblGroupRoles",
                columns: table => new
                {
                    RoleID = table.Column<Guid>(nullable: false),
                    GroupID = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateModified = table.Column<DateTimeOffset>(nullable: true),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblGroupRoles", x => new { x.GroupID, x.RoleID });
                    table.ForeignKey(
                        name: "FK_TblGroupRoles_TblGroups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "TblGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblGroupRoles_TblRoles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "TblRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblRoleRights",
                columns: table => new
                {
                    RoleID = table.Column<Guid>(nullable: false),
                    RightID = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateModified = table.Column<DateTimeOffset>(nullable: true),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblRoleRights", x => new { x.RightID, x.RoleID });
                    table.ForeignKey(
                        name: "FK_TblRoleRights_TblRights_RightID",
                        column: x => x.RightID,
                        principalTable: "TblRights",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblRoleRights_TblRoles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "TblRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblUserGroups",
                columns: table => new
                {
                    UserID = table.Column<Guid>(nullable: false),
                    GroupID = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateModified = table.Column<DateTimeOffset>(nullable: true),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUserGroups", x => new { x.UserID, x.GroupID });
                    table.UniqueConstraint("AK_TblUserGroups_GroupID_UserID", x => new { x.GroupID, x.UserID });
                    table.ForeignKey(
                        name: "FK_TblUserGroups_TblGroups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "TblGroups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblUserGroups_TblUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "TblUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblUserRights",
                columns: table => new
                {
                    UserID = table.Column<Guid>(nullable: false),
                    RightID = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateModified = table.Column<DateTimeOffset>(nullable: true),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUserRights", x => new { x.UserID, x.RightID });
                    table.UniqueConstraint("AK_TblUserRights_RightID_UserID", x => new { x.RightID, x.UserID });
                    table.ForeignKey(
                        name: "FK_TblUserRights_TblRights_RightID",
                        column: x => x.RightID,
                        principalTable: "TblRights",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblUserRights_TblUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "TblUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblUserRoles",
                columns: table => new
                {
                    UserID = table.Column<Guid>(nullable: false),
                    RoleID = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(nullable: false),
                    DateModified = table.Column<DateTimeOffset>(nullable: true),
                    TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblUserRoles", x => new { x.UserID, x.RoleID });
                    table.ForeignKey(
                        name: "FK_TblUserRoles_TblRoles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "TblRoles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblUserRoles_TblUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "TblUsers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblGroupRights_RightID",
                table: "TblGroupRights",
                column: "RightID");

            migrationBuilder.CreateIndex(
                name: "IX_TblGroupRoles_RoleID",
                table: "TblGroupRoles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_TblRoleRights_RoleID",
                table: "TblRoleRights",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_TblUserRoles_RoleID",
                table: "TblUserRoles",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblGroupRights");

            migrationBuilder.DropTable(
                name: "TblGroupRoles");

            migrationBuilder.DropTable(
                name: "TblRoleRights");

            migrationBuilder.DropTable(
                name: "TblUserGroups");

            migrationBuilder.DropTable(
                name: "TblUserRights");

            migrationBuilder.DropTable(
                name: "TblUserRoles");

            migrationBuilder.DropTable(
                name: "TblGroups");

            migrationBuilder.DropTable(
                name: "TblRights");

            migrationBuilder.DropTable(
                name: "TblRoles");

            migrationBuilder.DropTable(
                name: "TblUsers");
        }
    }
}
