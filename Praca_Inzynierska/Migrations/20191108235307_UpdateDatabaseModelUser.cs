using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska.Migrations
{
    public partial class UpdateDatabaseModelUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "03719819-6019-4aec-81e4-e5fb29163884", "AQAAAAEAACcQAAAAEAbXfY6KJxGZNC2IZyMFgGe/AZs5t0HLNzXAdYGzxrpm1xgg4nqSzCRlPvTlXIumyw==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Rola", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6ccd2a37-cdbc-457a-8519-bc8857bb45c7", 0, "fb0a7399-2b93-4caf-803e-b204240bfdd6", "admin@admin.pl", true, false, null, "Admin", "ADMIN@ADMIN.PL", "ADMIN@ADMIN.PL", "AQAAAAEAACcQAAAAEOrmSPEX2RkCU6HWEPl8FJUz9yH+noALK/GXC+3mThmQawBhh6CylNjxS0OkrlYo9w==", null, false, null, "", "Admin", false, "admin@admin.pl" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6ccd2a37-cdbc-457a-8519-bc8857bb45c7");

            migrationBuilder.DropColumn(
                name: "Rola",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b01bex90-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fbf22cda-8288-43b9-85b9-e77edd9055f7", "AQAAAAEAACcQAAAAEBsBJiwUUlsE7GFdV0HMMEITOzQ8l7Z+ymEnIs3QC8VyTNNCuJk5KDSSxinDt5VAcg==" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "c52036f1-fc03-4498-9fc4-f6fb1f1abd8a", 0, "f63c7efd-9595-4783-acdc-7b19bd70c8a0", "admin@admin.pl", true, false, null, "Admin", "ADMIN@ADMIN.PL", "ADMIN@ADMIN.PL", "AQAAAAEAACcQAAAAEP1yf/YmS7bJonvWHRawPfQ4Ah7FiZ8ubruKVn+PqqpjNXNVW4Wb8n3MmfOBIil43g==", null, false, "", "Admin", false, "admin@admin.pl" });
        }
    }
}
