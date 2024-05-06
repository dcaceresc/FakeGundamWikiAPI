using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FakeGundamWikiAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeExampleResult : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExampleResult",
                table: "Examples",
                type: "varchar(5000)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1000)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ExampleResult",
                table: "Examples",
                type: "varchar(1000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(5000)",
                oldNullable: true);
        }
    }
}
