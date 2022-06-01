using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactAdsAuthJWT.Data.Migrations
{
    public partial class tookawayname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Ads");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
