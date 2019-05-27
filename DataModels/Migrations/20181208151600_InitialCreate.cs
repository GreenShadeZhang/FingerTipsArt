using Microsoft.EntityFrameworkCore.Migrations;

namespace DataModels.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "origamis",
                columns: table => new
                {
                    OrigamiId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PicList = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Introduce = table.Column<string>(nullable: true),
                    Avatar = table.Column<string>(nullable: true),
                    MovieUrl = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_origamis", x => x.OrigamiId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "origamis");
        }
    }
}
