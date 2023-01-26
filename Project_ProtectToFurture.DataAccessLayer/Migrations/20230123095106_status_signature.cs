using Microsoft.EntityFrameworkCore.Migrations;

namespace Project_ProtectToFurture.DataAccessLayer.Migrations
{
    public partial class status_signature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "SignatureCampaigns",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "SignatureCampaigns");
        }
    }
}
