using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska.Migrations
{
    public partial class addAcountAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rola", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a1df72a8-d756-44f4-bd9b-60817997704e", 0, "93e8273e-9898-4852-838d-85f24cd8446c", "admin@admin.pl", true, false, null, "Admin", "ADMIN@ADMIN.PL", "ADMIN@ADMIN.PL", "AQAAAAEAACcQAAAAEPImPYC2Fphw9WnivjrYkzTEe/XQQqsT/igQuslyAsD2f2rOws7Uz6ZN1DfMsbALMw==", null, false, "Admin", "", "Admin", false, "admin@admin.pl" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
