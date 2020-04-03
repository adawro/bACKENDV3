using Microsoft.EntityFrameworkCore.Migrations;

namespace Praca_Inzynierska.Migrations
{
    public partial class test111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieImages_Actors_ActorId",
                table: "MovieImages");

            migrationBuilder.DropIndex(
                name: "IX_MovieImages_ActorId",
                table: "MovieImages");

            migrationBuilder.DropColumn(
                name: "ActorId",
                table: "MovieImages");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActorId",
                table: "MovieImages",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieImages_ActorId",
                table: "MovieImages",
                column: "ActorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieImages_Actors_ActorId",
                table: "MovieImages",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "ActorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
