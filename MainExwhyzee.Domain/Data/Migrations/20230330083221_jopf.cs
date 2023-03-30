using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainExwhyzee.Web.Data.Migrations
{
    public partial class jopf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainUrl",
                table: "SubAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OtherUrl",
                table: "SubAccounts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainUrl",
                table: "SubAccounts");

            migrationBuilder.DropColumn(
                name: "OtherUrl",
                table: "SubAccounts");
        }
    }
}
