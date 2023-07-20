using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutureSpaceAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Launchers",
                columns: table => new
                {
                    LaunchId = table.Column<Guid>(type: "TEXT", nullable: false),
                    LaunchJson = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Launchers", x => x.LaunchId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Launchers");
        }
    }
}
