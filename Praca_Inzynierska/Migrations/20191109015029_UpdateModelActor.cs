using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska.Migrations
{
    public partial class UpdateModelActor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AccountIdCreate",
                table: "Actors",
                newName: "AccountCreate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
                  migrationBuilder.RenameColumn(
                name: "AccountCreate",
                table: "Actors",
                newName: "AccountIdCreate");
        }
    }
}
