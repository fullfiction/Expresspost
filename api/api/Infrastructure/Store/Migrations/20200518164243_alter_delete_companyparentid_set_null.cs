using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Infrastructure.Store.Migrations
{
    public partial class alter_delete_companyparentid_set_null : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Companies_ParentId",
                table: "Companies");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Companies_ParentId",
                table: "Companies",
                column: "ParentId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Companies_ParentId",
                table: "Companies");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Companies_ParentId",
                table: "Companies",
                column: "ParentId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
