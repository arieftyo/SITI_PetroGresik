using Microsoft.EntityFrameworkCore.Migrations;

namespace SiTiPetro.Migrations.Aplikasi
{
    public partial class AddRencanaWeightFactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RencanaWeightFactor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BRD = table.Column<int>(nullable: false),
                    FinalisasiBRD = table.Column<int>(nullable: false),
                    Pengadaan = table.Column<double>(nullable: false),
                    DesainPrototype = table.Column<double>(nullable: false),
                    Pengembangan = table.Column<double>(nullable: false),
                    Testing = table.Column<int>(nullable: false),
                    EUT = table.Column<int>(nullable: false),
                    GoLive = table.Column<int>(nullable: false),
                    Support = table.Column<int>(nullable: false),
                    Closing = table.Column<int>(nullable: false),
                    AplikasiId = table.Column<int>(nullable: false)
                },

                constraints: table =>
                {
                    table.PrimaryKey("PK_RencanaWeightFactor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
               name: "IX_RencanaWeightFactor_AplikasiId",
               table: "RencanaWeightFactor",
               column: "AplikasiId",
               unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RencanaWeightFactor_Aplikasi_AplikasiId",
                table: "RencanaWeightFactor",
                column: "AplikasiId",
                principalTable: "Aplikasi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RencanaWeightFactor");
            
            migrationBuilder.DropForeignKey(
               name: "FK_RencanaWeightFactor_Aplikasi_AplikasiId",
               table: "RencanaWeightFactor");

            migrationBuilder.DropIndex(
                name: "IX_RencanaWeightFactor_AplikasiId",
                table: "RencanaWeightFactor");
        }
    }
}
