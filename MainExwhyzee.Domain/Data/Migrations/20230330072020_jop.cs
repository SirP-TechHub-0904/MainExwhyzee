using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainExwhyzee.Web.Data.Migrations
{
    public partial class jop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubAccounts_AccountTypes_AccountTypeId",
                table: "SubAccounts");

            migrationBuilder.DropIndex(
                name: "IX_SubAccounts_AccountTypeId",
                table: "SubAccounts");

            migrationBuilder.AddColumn<long>(
                name: "WDAccountId",
                table: "SubAccounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_SubAccounts_WDAccountId",
                table: "SubAccounts",
                column: "WDAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubAccounts_AccountTypes_WDAccountId",
                table: "SubAccounts",
                column: "WDAccountId",
                principalTable: "AccountTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubAccounts_AccountTypes_WDAccountId",
                table: "SubAccounts");

            migrationBuilder.DropIndex(
                name: "IX_SubAccounts_WDAccountId",
                table: "SubAccounts");

            migrationBuilder.DropColumn(
                name: "WDAccountId",
                table: "SubAccounts");

            migrationBuilder.CreateIndex(
                name: "IX_SubAccounts_AccountTypeId",
                table: "SubAccounts",
                column: "AccountTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubAccounts_AccountTypes_AccountTypeId",
                table: "SubAccounts",
                column: "AccountTypeId",
                principalTable: "AccountTypes",
                principalColumn: "Id");
        }
    }
}
