using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska.Migrations
{
    public partial class AddModelActor1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86e5e709-5845-45b1-bf82-77587dbf091e");

            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Born = table.Column<DateTime>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    CV = table.Column<string>(nullable: true),
                    CityBorn = table.Column<string>(nullable: true),
                    CountryBorn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b01bex90-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d4dea225-6d34-46dd-b259-b710edaf2b4f", "AQAAAAEAACcQAAAAEIYA3ubQ1jdlsCF5YxHigIT/CvRHoVTxG8rwGEqxwO30JKqsfNsl+5T/HmCzraAeww==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rola", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "67cde531-48d4-40f8-9de2-7f4e1eee3336", 0, "57602be9-979b-4cda-a157-d295354a8d02", "admin@admin.pl", true, false, null, "Admin", "ADMIN@ADMIN.PL", "ADMIN@ADMIN.PL", "AQAAAAEAACcQAAAAELn7Y0JtWh/jYoOcqlokPX/BTuKYpTsvwB9dHNOuXO16+RyeWVfZjPPFL5GQrJOxzQ==", null, false, "admin", "", "Admin", false, "admin@admin.pl" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "67cde531-48d4-40f8-9de2-7f4e1eee3336");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b01bex90-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "00fad311-55a0-4ae8-a3e5-50804ae54d57", "AQAAAAEAACcQAAAAEPCJzrhavwOzE9kPemP3i0Q559KsEdWufWLFoIrqcH/anmYdku+RnSH1aXqY0diSDw==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rola", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "86e5e709-5845-45b1-bf82-77587dbf091e", 0, "68d4f970-9950-4b1e-922c-1e62e87bbfdc", "admin@admin.pl", true, false, null, "Admin", "ADMIN@ADMIN.PL", "ADMIN@ADMIN.PL", "AQAAAAEAACcQAAAAEGu0t4JU8zkc3N9OXUG7fCa+hnqEh+ql/LG9UNxxO1osdErXXOPtGnUAesnw+tN1Mw==", null, false, "admin", "", "Admin", false, "admin@admin.pl" });
        }
    }
}
