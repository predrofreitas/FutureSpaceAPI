using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutureSpaceAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddImportDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ImportDate",
                table: "Launchers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImportDate",
                table: "Launchers");
        }
    }
}
