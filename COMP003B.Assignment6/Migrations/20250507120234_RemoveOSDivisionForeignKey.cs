using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP003B.Assignment6.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOSDivisionForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OSExperiences_OSDivisions_OSDivisionId",
                table: "OSExperiences");

            migrationBuilder.DropIndex(
                name: "IX_OSExperiences_OSDivisionId",
                table: "OSExperiences");

            migrationBuilder.DropColumn(
                name: "TechnicianAge",
                table: "Technicians");

            migrationBuilder.DropColumn(
                name: "OSDivisionId",
                table: "OSExperiences");

            migrationBuilder.AddColumn<int>(
                name: "OSDivisionDivisionId",
                table: "OSExperiences",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OSExperiences_OSDivisionDivisionId",
                table: "OSExperiences",
                column: "OSDivisionDivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_OSExperiences_OSDivisions_OSDivisionDivisionId",
                table: "OSExperiences",
                column: "OSDivisionDivisionId",
                principalTable: "OSDivisions",
                principalColumn: "DivisionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OSExperiences_OSDivisions_OSDivisionDivisionId",
                table: "OSExperiences");

            migrationBuilder.DropIndex(
                name: "IX_OSExperiences_OSDivisionDivisionId",
                table: "OSExperiences");

            migrationBuilder.DropColumn(
                name: "OSDivisionDivisionId",
                table: "OSExperiences");

            migrationBuilder.AddColumn<int>(
                name: "TechnicianAge",
                table: "Technicians",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OSDivisionId",
                table: "OSExperiences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_OSExperiences_OSDivisionId",
                table: "OSExperiences",
                column: "OSDivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_OSExperiences_OSDivisions_OSDivisionId",
                table: "OSExperiences",
                column: "OSDivisionId",
                principalTable: "OSDivisions",
                principalColumn: "DivisionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
