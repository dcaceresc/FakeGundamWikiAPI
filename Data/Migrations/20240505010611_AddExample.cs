using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FakeGundamWikiAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddExample : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExampleTypes",
                columns: table => new
                {
                    ExampleTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExampleTypeName = table.Column<string>(type: "varchar(100)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExampleTypes", x => x.ExampleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Examples",
                columns: table => new
                {
                    ExampleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExampleName = table.Column<string>(type: "varchar(100)", nullable: false),
                    ExampleCode = table.Column<string>(type: "varchar(1000)", nullable: false),
                    ExampleResult = table.Column<string>(type: "varchar(1000)", nullable: false),
                    ExampleTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examples", x => x.ExampleId);
                    table.ForeignKey(
                        name: "FK_Examples_ExampleTypes_ExampleTypeId",
                        column: x => x.ExampleTypeId,
                        principalTable: "ExampleTypes",
                        principalColumn: "ExampleTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Examples_ExampleTypeId",
                table: "Examples",
                column: "ExampleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExampleTypes_ExampleTypeName",
                table: "ExampleTypes",
                column: "ExampleTypeName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Examples");

            migrationBuilder.DropTable(
                name: "ExampleTypes");
        }
    }
}
