using Microsoft.EntityFrameworkCore.Migrations;

namespace APIDIS2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "description_fireballs",
                columns: table => new
                {
                    date_min = table.Column<string>(nullable: false),
                    date_max = table.Column<string>(nullable: true),
                    energy_min = table.Column<string>(nullable: true),
                    energy_max = table.Column<string>(nullable: true),
                    impact_e_min = table.Column<string>(nullable: true),
                    impact_e_max = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_description_fireballs", x => x.date_min);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "description_fireballs");
        }
    }
}
