using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP003B.Assignment6.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OSDivisions",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OSDivisionCourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OSDivisions", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_OSDivisions_OSDivisions_OSDivisionCourseId",
                        column: x => x.OSDivisionCourseId,
                        principalTable: "OSDivisions",
                        principalColumn: "CourseId");
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OSType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OSExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OSType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: true),
                    OSDivisionCourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OSExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OSExperiences_OSDivisions_OSDivisionCourseId",
                        column: x => x.OSDivisionCourseId,
                        principalTable: "OSDivisions",
                        principalColumn: "CourseId");
                    table.ForeignKey(
                        name: "FK_OSExperiences_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_OSDivisions_OSDivisionCourseId",
                table: "OSDivisions",
                column: "OSDivisionCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_OSExperiences_OSDivisionCourseId",
                table: "OSExperiences",
                column: "OSDivisionCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_OSExperiences_TechnicianId",
                table: "OSExperiences",
                column: "TechnicianId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OSExperiences");

            migrationBuilder.DropTable(
                name: "OSDivisions");

            migrationBuilder.DropTable(
                name: "Technicians");
        }
    }
}
