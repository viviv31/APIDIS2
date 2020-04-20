using Microsoft.EntityFrameworkCore.Migrations;

namespace APIDIS2.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "impact_e_min",
                table: "description_fireballs",
                newName: "longitude");

            migrationBuilder.RenameColumn(
                name: "impact_e_max",
                table: "description_fireballs",
                newName: "long_dir");

            migrationBuilder.RenameColumn(
                name: "energy_min",
                table: "description_fireballs",
                newName: "latitude");

            migrationBuilder.RenameColumn(
                name: "energy_max",
                table: "description_fireballs",
                newName: "lat_dir");

            migrationBuilder.RenameColumn(
                name: "date_max",
                table: "description_fireballs",
                newName: "impact_e");

            migrationBuilder.RenameColumn(
                name: "date_min",
                table: "description_fireballs",
                newName: "date");

            migrationBuilder.AddColumn<int>(
                name: "altitude",
                table: "description_fireballs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "energy",
                table: "description_fireballs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "velocity",
                table: "description_fireballs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "altitude",
                table: "description_fireballs");

            migrationBuilder.DropColumn(
                name: "energy",
                table: "description_fireballs");

            migrationBuilder.DropColumn(
                name: "velocity",
                table: "description_fireballs");

            migrationBuilder.RenameColumn(
                name: "longitude",
                table: "description_fireballs",
                newName: "impact_e_min");

            migrationBuilder.RenameColumn(
                name: "long_dir",
                table: "description_fireballs",
                newName: "impact_e_max");

            migrationBuilder.RenameColumn(
                name: "latitude",
                table: "description_fireballs",
                newName: "energy_min");

            migrationBuilder.RenameColumn(
                name: "lat_dir",
                table: "description_fireballs",
                newName: "energy_max");

            migrationBuilder.RenameColumn(
                name: "impact_e",
                table: "description_fireballs",
                newName: "date_max");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "description_fireballs",
                newName: "date_min");
        }
    }
}
