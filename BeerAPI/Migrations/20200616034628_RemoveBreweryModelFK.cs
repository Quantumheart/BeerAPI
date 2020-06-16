using Microsoft.EntityFrameworkCore.Migrations;

namespace BeerAPI.Migrations
{
    public partial class RemoveBreweryModelFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breweries_Breweries_BeerId",
                table: "Breweries");

            migrationBuilder.DropIndex(
                name: "IX_Breweries_BeerId",
                table: "Breweries");

            migrationBuilder.DropColumn(
                name: "BeerId",
                table: "Breweries");

            migrationBuilder.AlterColumn<decimal>(
                name: "Abv",
                table: "Beers",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BeerId",
                table: "Breweries",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Abv",
                table: "Beers",
                type: "decimal(3,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_Breweries_BeerId",
                table: "Breweries",
                column: "BeerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Breweries_Breweries_BeerId",
                table: "Breweries",
                column: "BeerId",
                principalTable: "Breweries",
                principalColumn: "BreweryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
