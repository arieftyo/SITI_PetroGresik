using Microsoft.EntityFrameworkCore.Migrations;

namespace SiTiPetro.Migrations.Aplikasi
{
    public partial class tambahPic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "pengerjaan",
                table: "Aplikasi",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "pic_ti_pi_pg",
                table: "Aplikasi",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pengerjaan",
                table: "Aplikasi");

            migrationBuilder.DropColumn(
                name: "pic_ti_pi_pg",
                table: "Aplikasi");
        }
    }
}
