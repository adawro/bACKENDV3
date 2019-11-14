using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska.Migrations
{
    public partial class AddActorNameToActor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9565d441-63c3-4d96-bee0-fcc5c87392df");

            migrationBuilder.AddColumn<string>(
                name: "ActorName",
                table: "Actors",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9697c362-903f-44e4-b286-68dbcd7b02b8");

            migrationBuilder.DropColumn(
                name: "ActorName",
                table: "Actors");

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
    }
}
