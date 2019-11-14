using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska.Migrations
{
    public partial class UpdateUserTestAndAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6ccd2a37-cdbc-457a-8519-bc8857bb45c7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b01bex90-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Rola" },
                values: new object[] { "d09b01c5-0754-4f97-ad8b-00246c5c9050", "AQAAAAEAACcQAAAAEE2vFjqXcgvKYISRzHzEalYuXfcinVbppm8EvP2zpNUrYMZp62KZyxDBbGukGutTqw==", "test" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rola", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "98eaa063-9911-4eff-b90b-e5e766618157", 0, "c807f0ac-6e93-4c9c-a78b-b51445595414", "admin@admin.pl", true, false, null, "Admin", "ADMIN@ADMIN.PL", "ADMIN@ADMIN.PL", "AQAAAAEAACcQAAAAEN5ZsoFZyNbqwaifSQU8Qu/DbVmJ0JQL6g9T4e0uKbuiHsj1M8XfYehZEOZp9KKXzg==", null, false, "admin", "", "Admin", false, "admin@admin.pl" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "98eaa063-9911-4eff-b90b-e5e766618157");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b01bex90-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Rola" },
                values: new object[] { "03719819-6019-4aec-81e4-e5fb29163884", "AQAAAAEAACcQAAAAEAbXfY6KJxGZNC2IZyMFgGe/AZs5t0HLNzXAdYGzxrpm1xgg4nqSzCRlPvTlXIumyw==", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rola", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6ccd2a37-cdbc-457a-8519-bc8857bb45c7", 0, "fb0a7399-2b93-4caf-803e-b204240bfdd6", "admin@admin.pl", true, false, null, "Admin", "ADMIN@ADMIN.PL", "ADMIN@ADMIN.PL", "AQAAAAEAACcQAAAAEOrmSPEX2RkCU6HWEPl8FJUz9yH+noALK/GXC+3mThmQawBhh6CylNjxS0OkrlYo9w==", null, false, null, "", "Admin", false, "admin@admin.pl" });
        }
    }
}
