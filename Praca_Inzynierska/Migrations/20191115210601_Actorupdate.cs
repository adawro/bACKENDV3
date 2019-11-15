using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska.Migrations
{
    public partial class Actorupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9697c362-903f-44e4-b286-68dbcd7b02b8");

            migrationBuilder.AddColumn<string>(
                name: "ActorSurname",
                table: "Actors",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b01bex90-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ae9af70c-8913-4654-80b7-0b74424e2dff", "AQAAAAEAACcQAAAAEIYrn0RPgkG4Ou6TwlQvRnBliHpjpWvacy/LNmBp0ffQaT3wRAQYk+6gyeBAmp8GKQ==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rola", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "91da34b6-9432-41b0-a056-cb3399439b2d", 0, "1aa09cda-6b81-4787-89cf-c9384a6b307c", "admin@admin.pl", true, false, null, "Admin", "ADMIN@ADMIN.PL", "ADMIN@ADMIN.PL", "AQAAAAEAACcQAAAAEM+2ykBpnIKh1NUUkv1D0QhR3AQFawR88mSR5FVU5zHI/OK1U0ES8lXYp7Vs9G4kKw==", null, false, "admin", "", "Admin", false, "admin@admin.pl" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "91da34b6-9432-41b0-a056-cb3399439b2d");

            migrationBuilder.DropColumn(
                name: "ActorSurname",
                table: "Actors");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b01bex90-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "34c23e3b-e68b-4308-82f8-4ada2b413770", "AQAAAAEAACcQAAAAEBE7NGjW6LflUJEzmFReHnoVlz//xVZp0QirPmCHoTMadIN8LCOR4lGDEVsyElUOww==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rola", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9697c362-903f-44e4-b286-68dbcd7b02b8", 0, "6452232f-7196-4dac-a8f4-83e6d4e15f27", "admin@admin.pl", true, false, null, "Admin", "ADMIN@ADMIN.PL", "ADMIN@ADMIN.PL", "AQAAAAEAACcQAAAAEHpZIMAAAHmHDu1iQ6hRv3xVqHmoDgiy4vK2Xf0ikdHuayRndQzJqsWEZep8Z/J5Ow==", null, false, "admin", "", "Admin", false, "admin@admin.pl" });
        }
    }
}
