using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_ProtectToFurture.DataAccessLayer.Migrations
{
    public partial class _signature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SignatureCampaigns",
                columns: table => new
                {
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CampaignCount = table.Column<int>(type: "int", nullable: false),
                    CampaignDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SignatureCampaigns", x => x.CampaignId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SignatureCampaigns");
        }
    }
}
