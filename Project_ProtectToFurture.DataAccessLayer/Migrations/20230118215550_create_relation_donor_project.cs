using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_ProtectToFurture.DataAccessLayer.Migrations
{
    public partial class create_relation_donor_project : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donars");

            migrationBuilder.CreateTable(
                name: "Donors",
                columns: table => new
                {
                    DonorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amout = table.Column<double>(type: "float", nullable: false),
                    DonorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DonorSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DonorAdress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DonorCity = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DonorEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DonorPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donors", x => x.DonorId);
                });

            migrationBuilder.CreateTable(
                name: "DonorProject",
                columns: table => new
                {
                    DonorId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonorProject", x => new { x.ProjectId, x.DonorId });
                    table.ForeignKey(
                        name: "FK_DonorProject_Donors_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Donors",
                        principalColumn: "DonorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonorProject_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonorProject_DonorId",
                table: "DonorProject",
                column: "DonorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonorProject");

            migrationBuilder.DropTable(
                name: "Donors");

            migrationBuilder.CreateTable(
                name: "Donars",
                columns: table => new
                {
                    DonarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amout = table.Column<double>(type: "float", nullable: false),
                    DonarAdress = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DonarCity = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    DonarEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DonarName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DonarPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonarSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donars", x => x.DonarId);
                });
        }
    }
}
