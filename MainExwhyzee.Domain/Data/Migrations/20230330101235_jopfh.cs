using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MainExwhyzee.Web.Data.Migrations
{
    public partial class jopfh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubAccounts_AccountTypes_WDAccountId",
                table: "SubAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AccountTypes",
                table: "AccountTypes");

            migrationBuilder.DropColumn(
                name: "AccountTypeId",
                table: "SubAccounts");

            migrationBuilder.RenameTable(
                name: "AccountTypes",
                newName: "WDAccounts");

            migrationBuilder.AlterColumn<long>(
                name: "WDAccountId",
                table: "SubAccounts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WDAccounts",
                table: "WDAccounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubAccounts_WDAccounts_WDAccountId",
                table: "SubAccounts",
                column: "WDAccountId",
                principalTable: "WDAccounts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubAccounts_WDAccounts_WDAccountId",
                table: "SubAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WDAccounts",
                table: "WDAccounts");

            migrationBuilder.RenameTable(
                name: "WDAccounts",
                newName: "AccountTypes");

            migrationBuilder.AlterColumn<long>(
                name: "WDAccountId",
                table: "SubAccounts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "AccountTypeId",
                table: "SubAccounts",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AccountTypes",
                table: "AccountTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubAccounts_AccountTypes_WDAccountId",
                table: "SubAccounts",
                column: "WDAccountId",
                principalTable: "AccountTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
