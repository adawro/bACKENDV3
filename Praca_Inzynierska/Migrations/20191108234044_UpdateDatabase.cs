using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a1df72a8-d756-44f4-bd9b-60817997704e");

            migrationBuilder.DropColumn(
                name: "Rola",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b01bex90-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "UserName" },
                values: new object[] { "fbf22cda-8288-43b9-85b9-e77edd9055f7", "AQAAAAEAACcQAAAAEBsBJiwUUlsE7GFdV0HMMEITOzQ8l7Z+ymEnIs3QC8VyTNNCuJk5KDSSxinDt5VAcg==", "test" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c52036f1-fc03-4498-9fc4-f6fb1f1abd8a", 0, "f63c7efd-9595-4783-acdc-7b19bd70c8a0", "admin@admin.pl", true, false, null, "Admin", "ADMIN@ADMIN.PL", "ADMIN@ADMIN.PL", "AQAAAAEAACcQAAAAEP1yf/YmS7bJonvWHRawPfQ4Ah7FiZ8ubruKVn+PqqpjNXNVW4Wb8n3MmfOBIil43g==", null, false, "", "Admin", false, "admin@admin.pl" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c52036f1-fc03-4498-9fc4-f6fb1f1abd8a");

            migrationBuilder.AddColumn<string>(
                name: "Rola",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b01bex90-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Rola", "UserName" },
                values: new object[] { "49694773-beac-41eb-bc4d-345132602169", "AQAAAAEAACcQAAAAECqsbZLsyGCnrjSLB8pc6VS9CnL9MEiYB1E3f+dP+5Q8ZiJwuOC4GMwKhwUqqFboIg==", "TEST", "test@test.test" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rola", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a1df72a8-d756-44f4-bd9b-60817997704e", 0, "93e8273e-9898-4852-838d-85f24cd8446c", "admin@admin.pl", true, false, null, "Admin", "ADMIN@ADMIN.PL", "ADMIN@ADMIN.PL", "AQAAAAEAACcQAAAAEPImPYC2Fphw9WnivjrYkzTEe/XQQqsT/igQuslyAsD2f2rOws7Uz6ZN1DfMsbALMw==", null, false, "Admin", "", "Admin", false, "admin@admin.pl" });
        }
    }
}
