using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska.Migrations
{
    public partial class AdminSeed1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b01bex90-aa65-4af8-bd17-00bd9344e1111");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rola", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b01bex90-aa65-4af8-bd17-00bd9344e789", 0, "8726c801-3c23-4115-b221-3c3d241b8af6", "admin@admin.pl", true, false, null, "Konto", "ADMIN@ADMIN.PL", "ADMIN@ADMIN.PL", "AQAAAAEAACcQAAAAELZ68sT7ag12VHVHalpACQBbMsH9lERhLxEqe+0Xp0rx946iAl/Z0Ob5jncj0kgjsA==", null, false, "admin", "", "Admin", false, "KontoAdmina" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b01bex90-aa65-4af8-bd17-00bd9344e789");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rola", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b01bex90-aa65-4af8-bd17-00bd9344e1111", 0, "05dd7aa4-f1b9-43b5-bc48-f6218b82351b", "admin@admin.pl", true, false, null, "Konto", "ADMIN@ADMIN.PL", "ADMIN@ADMIN.PL", "AQAAAAEAACcQAAAAECbsGa76d9JJkewpNHOnS0UeA7HQIFPmnDB4QAlIVk1YLoRBZsm6SG0DWOW/k26M3w==", null, false, "admin", "", "Admin", false, "KontoAdmina" });
        }
    }
}
