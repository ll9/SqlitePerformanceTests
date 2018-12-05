using Microsoft.EntityFrameworkCore.Migrations;

namespace SqlitePerformanceTests.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lichtpunkt",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Ort = table.Column<string>(nullable: true),
                    Straße = table.Column<string>(nullable: true),
                    Hausnummer = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lichtpunkt", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lichtpunkt");
        }
    }
}
