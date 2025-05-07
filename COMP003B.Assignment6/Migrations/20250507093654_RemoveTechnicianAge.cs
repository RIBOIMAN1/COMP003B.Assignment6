using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP003B.Assignment6.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTechnicianAge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OSDivisions_OSDivisions_OSDivisionCourseId",
                table: "OSDivisions");

            migrationBuilder.DropForeignKey(
                name: "FK_OSExperiences_OSDivisions_OSDivisionCourseId",
                table: "OSExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_OSExperiences_Technicians_TechnicianId",
                table: "OSExperiences");

            migrationBuilder.DropIndex(
                name: "IX_OSExperiences_OSDivisionCourseId",
                table: "OSExperiences");

            migrationBuilder.DropColumn(
                name: "OSDivisionCourseId",
                table: "OSExperiences");

            migrationBuilder.RenameColumn(
                name: "OSDivisionCourseId",
                table: "OSDivisions",
                newName: "OSDivisionDivisionId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "OSDivisions",
                newName: "DivisionId");

            migrationBuilder.RenameIndex(
                name: "IX_OSDivisions_OSDivisionCourseId",
                table: "OSDivisions",
                newName: "IX_OSDivisions_OSDivisionDivisionId");

            migrationBuilder.AddColumn<int>(
                name: "TechnicianAge",
                table: "Technicians",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TechnicianId",
                table: "OSExperiences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
                name: "FK_OSDivisions_OSDivisions_OSDivisionDivisionId",
                table: "OSDivisions",
                column: "OSDivisionDivisionId",
                principalTable: "OSDivisions",
                principalColumn: "DivisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_OSExperiences_OSDivisions_OSDivisionId",
                table: "OSExperiences",
                column: "OSDivisionId",
                principalTable: "OSDivisions",
                principalColumn: "DivisionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OSExperiences_Technicians_TechnicianId",
                table: "OSExperiences",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OSDivisions_OSDivisions_OSDivisionDivisionId",
                table: "OSDivisions");

            migrationBuilder.DropForeignKey(
                name: "FK_OSExperiences_OSDivisions_OSDivisionId",
                table: "OSExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_OSExperiences_Technicians_TechnicianId",
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

            migrationBuilder.RenameColumn(
                name: "OSDivisionDivisionId",
                table: "OSDivisions",
                newName: "OSDivisionCourseId");

            migrationBuilder.RenameColumn(
                name: "DivisionId",
                table: "OSDivisions",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_OSDivisions_OSDivisionDivisionId",
                table: "OSDivisions",
                newName: "IX_OSDivisions_OSDivisionCourseId");

            migrationBuilder.AlterColumn<int>(
                name: "TechnicianId",
                table: "OSExperiences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OSDivisionCourseId",
                table: "OSExperiences",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OSExperiences_OSDivisionCourseId",
                table: "OSExperiences",
                column: "OSDivisionCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_OSDivisions_OSDivisions_OSDivisionCourseId",
                table: "OSDivisions",
                column: "OSDivisionCourseId",
                principalTable: "OSDivisions",
                principalColumn: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_OSExperiences_OSDivisions_OSDivisionCourseId",
                table: "OSExperiences",
                column: "OSDivisionCourseId",
                principalTable: "OSDivisions",
                principalColumn: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_OSExperiences_Technicians_TechnicianId",
                table: "OSExperiences",
                column: "TechnicianId",
                principalTable: "Technicians",
                principalColumn: "Id");
        }
    }
}
