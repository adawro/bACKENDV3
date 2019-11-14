using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska.Migrations
{
    public partial class UpdateModelActor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d55e21d-fb30-42ca-abc9-20ba91636b88");

            migrationBuilder.RenameColumn(
                name: "AccountIdCreate",
                table: "Actors",
                newName: "AccountCreate");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b01bex90-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4c7bda09-56f7-40e1-a8cb-e2a71c55d61d", "AQAAAAEAACcQAAAAEOmGGd4c5dlBB8TCqfiwcgdYQdUocobgAIw9JNRtZNf9FbHGK5HeNOvOH/zey4k+vA==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rola", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9565d441-63c3-4d96-bee0-fcc5c87392df", 0, "1ea4bc25-96b7-4638-9c6d-0b5fd7f50508", "admin@admin.pl", true, false, null, "Admin", "ADMIN@ADMIN.PL", "ADMIN@ADMIN.PL", "AQAAAAEAACcQAAAAEMzGCrZJgzwtkxBohqqKl8CyC/XiEnStlx7lbQfsujGKOAwzDTjKM8Y1CNqD7C274Q==", null, false, "admin", "", "Admin", false, "admin@admin.pl" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9565d441-63c3-4d96-bee0-fcc5c87392df");

            migrationBuilder.RenameColumn(
                name: "AccountCreate",
                table: "Actors",
                newName: "AccountIdCreate");

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
    }
}
