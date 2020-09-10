using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace api.Infrastructure.Store.Migrations
{
    public partial class admins_to_employees_compnay_employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCountries_Companies_CompanyId",
                table: "CompanyCountries");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCountries_Countries_CountryId",
                table: "CompanyCountries");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyCountries",
                table: "CompanyCountries");

            migrationBuilder.RenameTable(
                name: "CompanyCountries",
                newName: "CompanyCountry");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyCountries_CountryId",
                table: "CompanyCountry",
                newName: "IX_CompanyCountry_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyCountries_CompanyId",
                table: "CompanyCountry",
                newName: "IX_CompanyCountry_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyCountry",
                table: "CompanyCountry",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SequenceHiLo),
                    Created = table.Column<DateTime>(nullable: false),
                    Username = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompanyEmployee",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SequenceHiLo),
                    Created = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<long>(nullable: false),
                    CompanyId = table.Column<long>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyEmployee_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyEmployee_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEmployee_CompanyId",
                table: "CompanyEmployee",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyEmployee_EmployeeId",
                table: "CompanyEmployee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Username",
                table: "Employees",
                column: "Username",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCountry_Companies_CompanyId",
                table: "CompanyCountry",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCountry_Countries_CountryId",
                table: "CompanyCountry",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCountry_Companies_CompanyId",
                table: "CompanyCountry");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyCountry_Countries_CountryId",
                table: "CompanyCountry");

            migrationBuilder.DropTable(
                name: "CompanyEmployee");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyCountry",
                table: "CompanyCountry");

            migrationBuilder.RenameTable(
                name: "CompanyCountry",
                newName: "CompanyCountries");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyCountry_CountryId",
                table: "CompanyCountries",
                newName: "IX_CompanyCountries_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyCountry_CompanyId",
                table: "CompanyCountries",
                newName: "IX_CompanyCountries_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyCountries",
                table: "CompanyCountries",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SequenceHiLo),
                    Created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Username",
                table: "Admins",
                column: "Username",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCountries_Companies_CompanyId",
                table: "CompanyCountries",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyCountries_Countries_CountryId",
                table: "CompanyCountries",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
