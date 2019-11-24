using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActorName",
                table: "MoviesToActor",
                newName: "ActorNameInMovie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActorNameInMovie",
                table: "MoviesToActor",
                newName: "ActorName");
        }
    }
}
