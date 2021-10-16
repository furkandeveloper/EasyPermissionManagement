using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyPermissionManagement.PostgreSql.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "easy-permissions");

            migrationBuilder.CreateTable(
                name: "Permissions",
                schema: "easy-permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Provider = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_CreateDate_UpdateDate_Key_Provider",
                schema: "easy-permissions",
                table: "Permissions",
                columns: new[] { "CreateDate", "UpdateDate", "Key", "Provider" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions",
                schema: "easy-permissions");
        }
    }
}
