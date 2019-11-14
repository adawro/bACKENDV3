using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "67cde531-48d4-40f8-9de2-7f4e1eee3336");

            migrationBuilder.AddColumn<string>(
                name: "AccountIdCreate",
                table: "Actors",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b01bex90-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7dca9d1f-e85e-4b41-a223-9d9799b1f20d", "AQAAAAEAACcQAAAAEDgNo5pAp9o95ljKW/XStSY+LakdnBQWDgve/11F03S2uOqw8RXA0X4Smt+TTQvd8w==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rola", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7d55e21d-fb30-42ca-abc9-20ba91636b88", 0, "b965ea2b-8517-4ea4-8eae-db7d5076c566", "admin@admin.pl", true, false, null, "Admin", "ADMIN@ADMIN.PL", "ADMIN@ADMIN.PL", "AQAAAAEAACcQAAAAEL9ZXJaI2jGlNS1n78PHOpYGvDCLXJ+QXLX7AD8/Og8oeHHL6DEhX4He3plhGm2cKQ==", null, false, "admin", "", "Admin", false, "admin@admin.pl" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d55e21d-fb30-42ca-abc9-20ba91636b88");

            migrationBuilder.DropColumn(
                name: "AccountIdCreate",
                table: "Actors");

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
    }
}
