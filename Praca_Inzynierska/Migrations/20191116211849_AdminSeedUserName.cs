using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska.Migrations
{
    public partial class AdminSeedUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b01bex90-aa65-4af8-bd17-00bd9344e789",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "0bdf4986-ac94-41fb-86cf-0932070e5a9c", "KONTOADMINA", "AQAAAAEAACcQAAAAEF3t+1JfWju2TQdrr04i0m25+pMMWz2q8L7oXm4dKIfwD2ZS2iiHCWDwdVOz/8+DXA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b01bex90-aa65-4af8-bd17-00bd9344e789",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "8726c801-3c23-4115-b221-3c3d241b8af6", "ADMIN@ADMIN.PL", "AQAAAAEAACcQAAAAELZ68sT7ag12VHVHalpACQBbMsH9lERhLxEqe+0Xp0rx946iAl/Z0Ob5jncj0kgjsA==" });
        }
    }
}
