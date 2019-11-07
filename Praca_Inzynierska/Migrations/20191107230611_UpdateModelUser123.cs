using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska.Migrations
{
    public partial class UpdateModelUser123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rola",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
               table: "AspNetUsers",
               columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Name", "Surname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Rola" },
               values: new object[] { "b01bex90-aa65-4af8-bd17-00bd9344e575", 0, "651ec58e-cc5a-45da-a5ec-cfede9c1911d", "test@test.test", true, "Konto", "Testowe", false, null, "TEST@TEST.TEST", "TEST@TEST.TEST", "AQAAAAEAACcQAAAAEJFqScrdk+4XcBaC+7TCBnWtLJVMxfSwkifYus1zn1q0Is8FIjolV19YVoKrzEHLiA==", null, false, "", false, "test@test.test", "TEST" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b01bex90-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ea1f905a-f1d8-4b92-b3eb-672e44e85139", "AQAAAAEAACcQAAAAENFM6A0C+RlLWePfQ/iZXoasjkZEdmiod4KZUKZpFJTwjcUpclMtNu4fWMC91O7w7Q==" });
        }
    }
}
