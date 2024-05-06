using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FakeGundamWikiAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifyExample : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "ExampleTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "ExampleTypes",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "ExampleTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "ExampleTypes",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Examples",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Examples",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Examples",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Examples",
                type: "varchar(30)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "ExampleTypes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ExampleTypes");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "ExampleTypes");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "ExampleTypes");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Examples");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Examples");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Examples");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Examples");
        }
    }
}
