using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyPermissionManagement.PostgreSql.Migrations
{
    public partial class AddIdentifierPermissionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentifierPermissions",
                schema: "easy-permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uuid", nullable: false),
                    IdentifierKey = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentifierPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentifierPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "easy-permissions",
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IdentifierPermissions_CreateDate_UpdateDate_IdentifierKey",
                schema: "easy-permissions",
                table: "IdentifierPermissions",
                columns: new[] { "CreateDate", "UpdateDate", "IdentifierKey" });

            migrationBuilder.CreateIndex(
                name: "IX_IdentifierPermissions_PermissionId",
                schema: "easy-permissions",
                table: "IdentifierPermissions",
                column: "PermissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentifierPermissions",
                schema: "easy-permissions");
        }
    }
}
