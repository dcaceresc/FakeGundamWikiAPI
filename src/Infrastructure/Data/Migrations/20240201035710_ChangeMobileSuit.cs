using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMobileSuit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitType",
                table: "MobileSuits",
                newName: "MobileSuitUnitType");

            migrationBuilder.RenameColumn(
                name: "LastSeen",
                table: "MobileSuits",
                newName: "MobileSuitLastSeen");

            migrationBuilder.RenameColumn(
                name: "FirstSeen",
                table: "MobileSuits",
                newName: "MobileSuitFirstSeen");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "MobileSuits",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "MobileSuits");

            migrationBuilder.RenameColumn(
                name: "MobileSuitUnitType",
                table: "MobileSuits",
                newName: "UnitType");

            migrationBuilder.RenameColumn(
                name: "MobileSuitLastSeen",
                table: "MobileSuits",
                newName: "LastSeen");

            migrationBuilder.RenameColumn(
                name: "MobileSuitFirstSeen",
                table: "MobileSuits",
                newName: "FirstSeen");
        }
    }
}
