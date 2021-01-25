using Microsoft.EntityFrameworkCore.Migrations;

namespace SiTiPetro.Migrations.Aplikasi
{
    public partial class AddLaporanTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Laporan",
               columns: table => new
               {
                   Id = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Bulan = table.Column<int>(nullable: true),
                   File = table.Column<string>(nullable: true),
                   FileName = table.Column<string>(nullable: true),
                   AplikasiId = table.Column<int>(nullable: false)
               },

               constraints: table =>
               {
                   table.PrimaryKey("PK_Laporan", x => x.Id);
               });

            migrationBuilder.CreateIndex(
               name: "IX_Laporan_AplikasiId",
               table: "Laporan",
               column: "AplikasiId",
               unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Laporan_Aplikasi_AplikasiId",
                table: "Laporan",
                column: "AplikasiId",
                principalTable: "Aplikasi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
             migrationBuilder.DropTable(
                name: "Laporan");

            migrationBuilder.DropForeignKey(
               name: "FK_Laporan_Aplikasi_AplikasiId",
               table: "Laporan");

            migrationBuilder.DropIndex(
                name: "IX_Laporan_AplikasiId",
                table: "Laporan");
        }
    }
}
