using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska.Migrations
{
    public partial class addAcountAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b01bex90-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "Name", "PasswordHash" },
                values: new object[] { "49694773-beac-41eb-bc4d-345132602169", "Konto", "AQAAAAEAACcQAAAAECqsbZLsyGCnrjSLB8pc6VS9CnL9MEiYB1E3f+dP+5Q8ZiJwuOC4GMwKhwUqqFboIg==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rola", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a1df72a8-d756-44f4-bd9b-60817997704e", 0, "93e8273e-9898-4852-838d-85f24cd8446c", "admin@admin.pl", true, false, null, "Admin", "ADMIN@ADMIN.PL", "ADMIN@ADMIN.PL", "AQAAAAEAACcQAAAAEPImPYC2Fphw9WnivjrYkzTEe/XQQqsT/igQuslyAsD2f2rOws7Uz6ZN1DfMsbALMw==", null, false, "Admin", "", "Admin", false, "admin@admin.pl" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1df72a8-d756-44f4-bd9b-60817997704e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b01bex90-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "Name", "PasswordHash" },
                values: new object[] { "e97bb1bf-bf8a-4d09-8139-d3c99d131aef", "Kontoooooooooooo", "AQAAAAEAACcQAAAAEGSwMyFwXFto2dN2tMtGxVttwX4hSslELA/QdVTcLps6lSaX4OozAFtxya21cmUdBg==" });
        }
    }
}
