using Microsoft.EntityFrameworkCore.Migrations;

namespace ReactAdsAuthJWT.Data.Migrations
{
    public partial class removedname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserFirstName",
                table: "Ads");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserFirstName",
                table: "Ads",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
