using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSerieToMobileSuit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SerieId",
                table: "MobileSuits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MobileSuits_SerieId",
                table: "MobileSuits",
                column: "SerieId");

            migrationBuilder.AddForeignKey(
                name: "FK_MobileSuits_Series_SerieId",
                table: "MobileSuits",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "SerieId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MobileSuits_Series_SerieId",
                table: "MobileSuits");

            migrationBuilder.DropIndex(
                name: "IX_MobileSuits_SerieId",
                table: "MobileSuits");

            migrationBuilder.DropColumn(
                name: "SerieId",
                table: "MobileSuits");
        }
    }
}
