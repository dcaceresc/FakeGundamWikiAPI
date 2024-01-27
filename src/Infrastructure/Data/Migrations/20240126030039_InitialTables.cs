using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Affiliations",
                columns: table => new
                {
                    AffiliationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AffiliationName = table.Column<string>(type: "varchar(100)", nullable: false),
                    AffiliationPurpose = table.Column<string>(type: "varchar(200)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(30)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affiliations", x => x.AffiliationId);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aliases = table.Column<string>(type: "varchar(200)", nullable: false),
                    CharacterName = table.Column<string>(type: "varchar(100)", nullable: false),
                    Classification = table.Column<string>(type: "varchar(100)", nullable: false),
                    BirthDate = table.Column<string>(type: "varchar(50)", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(30)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    ManufacturerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManufacturerName = table.Column<string>(type: "varchar(100)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(30)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.ManufacturerId);
                });

            migrationBuilder.CreateTable(
                name: "Universes",
                columns: table => new
                {
                    UniverseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniverseName = table.Column<string>(type: "varchar(100)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(30)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universes", x => x.UniverseId);
                });

            migrationBuilder.CreateTable(
                name: "CharacterAffiliations",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    AffiliationId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(30)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterAffiliations", x => new { x.CharacterId, x.AffiliationId });
                    table.ForeignKey(
                        name: "FK_CharacterAffiliations_Affiliations_AffiliationId",
                        column: x => x.AffiliationId,
                        principalTable: "Affiliations",
                        principalColumn: "AffiliationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterAffiliations_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MobileSuits",
                columns: table => new
                {
                    MobileSuitId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MobileSuitName = table.Column<string>(type: "varchar(100)", nullable: false),
                    UnitType = table.Column<string>(type: "varchar(100)", nullable: false),
                    FirstSeen = table.Column<string>(type: "varchar(50)", nullable: false),
                    LastSeen = table.Column<string>(type: "varchar(50)", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(30)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileSuits", x => x.MobileSuitId);
                    table.ForeignKey(
                        name: "FK_MobileSuits_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "ManufacturerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    SerieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerieName = table.Column<string>(type: "varchar(100)", nullable: false),
                    UniverseId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(30)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.SerieId);
                    table.ForeignKey(
                        name: "FK_Series_Universes_UniverseId",
                        column: x => x.UniverseId,
                        principalTable: "Universes",
                        principalColumn: "UniverseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MobileSuitPilots",
                columns: table => new
                {
                    MobileSuitId = table.Column<int>(type: "int", nullable: false),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(30)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileSuitPilots", x => new { x.CharacterId, x.MobileSuitId });
                    table.ForeignKey(
                        name: "FK_MobileSuitPilots_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MobileSuitPilots_MobileSuits_MobileSuitId",
                        column: x => x.MobileSuitId,
                        principalTable: "MobileSuits",
                        principalColumn: "MobileSuitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Affiliations_AffiliationName",
                table: "Affiliations",
                column: "AffiliationName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CharacterAffiliations_AffiliationId",
                table: "CharacterAffiliations",
                column: "AffiliationId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_CharacterName",
                table: "Characters",
                column: "CharacterName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_ManufacturerName",
                table: "Manufacturers",
                column: "ManufacturerName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MobileSuitPilots_MobileSuitId",
                table: "MobileSuitPilots",
                column: "MobileSuitId");

            migrationBuilder.CreateIndex(
                name: "IX_MobileSuits_ManufacturerId",
                table: "MobileSuits",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_MobileSuits_MobileSuitName",
                table: "MobileSuits",
                column: "MobileSuitName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Series_SerieName",
                table: "Series",
                column: "SerieName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Series_UniverseId",
                table: "Series",
                column: "UniverseId");

            migrationBuilder.CreateIndex(
                name: "IX_Universes_UniverseName",
                table: "Universes",
                column: "UniverseName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterAffiliations");

            migrationBuilder.DropTable(
                name: "MobileSuitPilots");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Affiliations");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "MobileSuits");

            migrationBuilder.DropTable(
                name: "Universes");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
