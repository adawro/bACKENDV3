using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska.Migrations
{
    public partial class AddModelActor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98eaa063-9911-4eff-b90b-e5e766618157");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86e5e709-5845-45b1-bf82-77587dbf091e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b01bex90-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d09b01c5-0754-4f97-ad8b-00246c5c9050", "AQAAAAEAACcQAAAAEE2vFjqXcgvKYISRzHzEalYuXfcinVbppm8EvP2zpNUrYMZp62KZyxDBbGukGutTqw==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rola", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "98eaa063-9911-4eff-b90b-e5e766618157", 0, "c807f0ac-6e93-4c9c-a78b-b51445595414", "admin@admin.pl", true, false, null, "Admin", "ADMIN@ADMIN.PL", "ADMIN@ADMIN.PL", "AQAAAAEAACcQAAAAEN5ZsoFZyNbqwaifSQU8Qu/DbVmJ0JQL6g9T4e0uKbuiHsj1M8XfYehZEOZp9KKXzg==", null, false, "admin", "", "Admin", false, "admin@admin.pl" });
        }
    }
}
