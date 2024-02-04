using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCharacter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GenderId",
                table: "Characters",
                newName: "CharacterGenderId");

            migrationBuilder.RenameColumn(
                name: "Classification",
                table: "Characters",
                newName: "CharacterClassification");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Characters",
                newName: "CharacterBirthDate");

            migrationBuilder.RenameColumn(
                name: "Aliases",
                table: "Characters",
                newName: "CharacterAliases");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CharacterGenderId",
                table: "Characters",
                newName: "GenderId");

            migrationBuilder.RenameColumn(
                name: "CharacterClassification",
                table: "Characters",
                newName: "Classification");

            migrationBuilder.RenameColumn(
                name: "CharacterBirthDate",
                table: "Characters",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "CharacterAliases",
                table: "Characters",
                newName: "Aliases");
        }
    }
}
