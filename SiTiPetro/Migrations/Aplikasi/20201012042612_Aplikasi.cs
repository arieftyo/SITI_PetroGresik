using Microsoft.EntityFrameworkCore.Migrations;

namespace SiTiPetro.Migrations.Aplikasi
{
    public partial class Aplikasi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aplikasi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nama = table.Column<string>(nullable: true),
                    deskripsi = table.Column<string>(nullable: true),
                    nomor_surat_dof = table.Column<string>(nullable: true),
                    direktorat = table.Column<string>(nullable: true),
                    kompartemen = table.Column<string>(nullable: true),
                    departermen = table.Column<string>(nullable: true),
                    upload_brd = table.Column<string>(nullable: true),
                    pic_unit_terkait = table.Column<string>(nullable: true),
                    nomer_hp = table.Column<string>(nullable: true),
                    tahun = table.Column<int>(nullable: false),
                    jenis_aplikasi = table.Column<int>(nullable: false),
                    rencana_anggaran = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplikasi", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aplikasi");
        }
    }
}
