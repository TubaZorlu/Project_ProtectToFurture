using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_ProtectToFurture.DataAccessLayer.Migrations
{
    public partial class update_campaign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SignatureCampaigns");

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CampaignDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.CampaignId);
                });

            migrationBuilder.CreateTable(
                name: "Signatures",
                columns: table => new
                {
                    SignatureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SignatureCount = table.Column<int>(type: "int", nullable: false),
                    SignatureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signatures", x => x.SignatureId);
                    table.ForeignKey(
                        name: "FK_Signatures_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Signatures_CampaignId",
                table: "Signatures",
                column: "CampaignId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Signatures");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.CreateTable(
                name: "SignatureCampaigns",
                columns: table => new
                {
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignCount = table.Column<int>(type: "int", nullable: false),
                    CampaignDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CampaignName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignatureCampaigns", x => x.CampaignId);
                });
        }
    }
}
