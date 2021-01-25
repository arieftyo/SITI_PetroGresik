using Microsoft.EntityFrameworkCore.Migrations;

namespace SiTiPetro.Migrations.Aplikasi
{
    public partial class AplikasiAddPM_BA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ba",
                table: "Aplikasi",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "pm",
                table: "Aplikasi",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ba",
                table: "Aplikasi");

            migrationBuilder.DropColumn(
                name: "pm",
                table: "Aplikasi");
        }
    }
}
