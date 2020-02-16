using Microsoft.EntityFrameworkCore.Migrations;

namespace ItunesSearchData.Migrations
{
    public partial class DeleteToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "Accounts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "Accounts",
                type: "text",
                nullable: true);
        }
    }
}
