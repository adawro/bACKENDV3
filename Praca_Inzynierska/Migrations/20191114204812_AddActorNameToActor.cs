using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska.Migrations
{
    public partial class AddActorNameToActor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {            
            migrationBuilder.AddColumn<string>(
                name: "ActorName",
                table: "Actors",
                nullable: true);      
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {         
            migrationBuilder.DropColumn(
                name: "ActorName",
                table: "Actors");
        }
    }
}
