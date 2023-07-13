using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutureSpaceAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeLauncherNameMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Launches_LaunchServiceProviders_LaunchServiceProviderId",
                table: "Launches");

            migrationBuilder.DropForeignKey(
                name: "FK_Launches_Pads_PadId",
                table: "Launches");

            migrationBuilder.DropForeignKey(
                name: "FK_Launches_Rockets_RocketId",
                table: "Launches");

            migrationBuilder.DropForeignKey(
                name: "FK_Launches_Status_StatusId",
                table: "Launches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Launches",
                table: "Launches");

            migrationBuilder.RenameTable(
                name: "Launches",
                newName: "Launchers");

            migrationBuilder.RenameIndex(
                name: "IX_Launches_StatusId",
                table: "Launchers",
                newName: "IX_Launchers_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Launches_RocketId",
                table: "Launchers",
                newName: "IX_Launchers_RocketId");

            migrationBuilder.RenameIndex(
                name: "IX_Launches_PadId",
                table: "Launchers",
                newName: "IX_Launchers_PadId");

            migrationBuilder.RenameIndex(
                name: "IX_Launches_LaunchServiceProviderId",
                table: "Launchers",
                newName: "IX_Launchers_LaunchServiceProviderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Launchers",
                table: "Launchers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Launchers_LaunchServiceProviders_LaunchServiceProviderId",
                table: "Launchers",
                column: "LaunchServiceProviderId",
                principalTable: "LaunchServiceProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Launchers_Pads_PadId",
                table: "Launchers",
                column: "PadId",
                principalTable: "Pads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Launchers_Rockets_RocketId",
                table: "Launchers",
                column: "RocketId",
                principalTable: "Rockets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Launchers_Status_StatusId",
                table: "Launchers",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Launchers_LaunchServiceProviders_LaunchServiceProviderId",
                table: "Launchers");

            migrationBuilder.DropForeignKey(
                name: "FK_Launchers_Pads_PadId",
                table: "Launchers");

            migrationBuilder.DropForeignKey(
                name: "FK_Launchers_Rockets_RocketId",
                table: "Launchers");

            migrationBuilder.DropForeignKey(
                name: "FK_Launchers_Status_StatusId",
                table: "Launchers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Launchers",
                table: "Launchers");

            migrationBuilder.RenameTable(
                name: "Launchers",
                newName: "Launches");

            migrationBuilder.RenameIndex(
                name: "IX_Launchers_StatusId",
                table: "Launches",
                newName: "IX_Launches_StatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Launchers_RocketId",
                table: "Launches",
                newName: "IX_Launches_RocketId");

            migrationBuilder.RenameIndex(
                name: "IX_Launchers_PadId",
                table: "Launches",
                newName: "IX_Launches_PadId");

            migrationBuilder.RenameIndex(
                name: "IX_Launchers_LaunchServiceProviderId",
                table: "Launches",
                newName: "IX_Launches_LaunchServiceProviderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Launches",
                table: "Launches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Launches_LaunchServiceProviders_LaunchServiceProviderId",
                table: "Launches",
                column: "LaunchServiceProviderId",
                principalTable: "LaunchServiceProviders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Launches_Pads_PadId",
                table: "Launches",
                column: "PadId",
                principalTable: "Pads",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Launches_Rockets_RocketId",
                table: "Launches",
                column: "RocketId",
                principalTable: "Rockets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Launches_Status_StatusId",
                table: "Launches",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
