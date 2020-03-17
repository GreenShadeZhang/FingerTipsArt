using Microsoft.EntityFrameworkCore.Migrations;

namespace DataModels.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "origamis",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameId",
                table: "origamis",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "origamis");

            migrationBuilder.DropColumn(
                name: "NameId",
                table: "origamis");
        }
    }
}
