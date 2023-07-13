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
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LaunchLibraryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Family = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    Variant = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaunchServiceProviders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaunchServiceProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CountryCode = table.Column<string>(type: "TEXT", nullable: false),
                    MapImage = table.Column<string>(type: "TEXT", nullable: false),
                    TotalLaunchCount = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalLandingCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rockets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConfigurationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rockets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rockets_Configurations_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "Configurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    AgencyId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    InfoUrl = table.Column<string>(type: "TEXT", nullable: false),
                    WikiUrl = table.Column<string>(type: "TEXT", nullable: false),
                    MapUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Latitude = table.Column<string>(type: "TEXT", nullable: false),
                    Longitude = table.Column<string>(type: "TEXT", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: false),
                    MapImage = table.Column<string>(type: "TEXT", nullable: false),
                    TotalLaunchCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pads_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Launches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    LaunchLibraryId = table.Column<int>(type: "INTEGER", nullable: false),
                    Slug = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    StatusId = table.Column<int>(type: "INTEGER", nullable: false),
                    ImportDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Net = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WindowEnd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WindowStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InHold = table.Column<bool>(type: "INTEGER", nullable: false),
                    TbdTime = table.Column<bool>(type: "INTEGER", nullable: false),
                    TbdDate = table.Column<bool>(type: "INTEGER", nullable: false),
                    Probability = table.Column<int>(type: "INTEGER", nullable: false),
                    HoldReason = table.Column<string>(type: "TEXT", nullable: false),
                    FailReason = table.Column<string>(type: "TEXT", nullable: false),
                    Hashtag = table.Column<string>(type: "TEXT", nullable: false),
                    LaunchServiceProviderId = table.Column<int>(type: "INTEGER", nullable: false),
                    RocketId = table.Column<int>(type: "INTEGER", nullable: false),
                    PadId = table.Column<int>(type: "INTEGER", nullable: false),
                    WebcastLive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Image = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Launches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Launches_LaunchServiceProviders_LaunchServiceProviderId",
                        column: x => x.LaunchServiceProviderId,
                        principalTable: "LaunchServiceProviders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Launches_Pads_PadId",
                        column: x => x.PadId,
                        principalTable: "Pads",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Launches_Rockets_RocketId",
                        column: x => x.RocketId,
                        principalTable: "Rockets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Launches_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Launches_LaunchServiceProviderId",
                table: "Launches",
                column: "LaunchServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Launches_PadId",
                table: "Launches",
                column: "PadId");

            migrationBuilder.CreateIndex(
                name: "IX_Launches_RocketId",
                table: "Launches",
                column: "RocketId");

            migrationBuilder.CreateIndex(
                name: "IX_Launches_StatusId",
                table: "Launches",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Pads_LocationId",
                table: "Pads",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rockets_ConfigurationId",
                table: "Rockets",
                column: "ConfigurationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Launches");

            migrationBuilder.DropTable(
                name: "LaunchServiceProviders");

            migrationBuilder.DropTable(
                name: "Pads");

            migrationBuilder.DropTable(
                name: "Rockets");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Configurations");
        }
    }
}
