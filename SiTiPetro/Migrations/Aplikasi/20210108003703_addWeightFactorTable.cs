using Microsoft.EntityFrameworkCore.Migrations;

namespace SiTiPetro.Migrations.Aplikasi
{
    public partial class addWeightFactorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeightFactor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileBrd = table.Column<string>(nullable: true),
                    FileLogo = table.Column<string>(nullable: true),
                    FileTor = table.Column<string>(nullable: true),
                    FileOkPrPo = table.Column<string>(nullable: true),
                    FileUserManualgembangan = table.Column<string>(nullable: true),
                    FileUat = table.Column<string>(nullable: true),
                    FileEut = table.Column<string>(nullable: true),
                    FileBa = table.Column<string>(nullable: true),
                    FileChangeRequest = table.Column<string>(nullable: true),
                    FileIk = table.Column<string>(nullable: true),
                    FileProsedur = table.Column<string>(nullable: true),
                    LinkWebsite = table.Column<string>(nullable: true),
                    LinkMobileAndroid = table.Column<string>(nullable: true),
                    LinkMobileiOs = table.Column<string>(nullable: true),
                    Server = table.Column<string>(nullable: true),
                    Database = table.Column<string>(nullable: true),
                    AplikasiId = table.Column<int>(nullable: false)
                },

                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightFactor", x => x.Id);
                });

            migrationBuilder.CreateIndex(
               name: "IX_WeightFactor_AplikasiId",
               table: "WeightFactor",
               column: "AplikasiId",
               unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WeightFactor_Aplikasi_AplikasiId",
                table: "WeightFactor",
                column: "AplikasiId",
                principalTable: "Aplikasi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeightFactor");

            migrationBuilder.DropForeignKey(
               name: "FK_WeightFactor_Aplikasi_AplikasiId",
               table: "WeightFactor");

            migrationBuilder.DropIndex(
                name: "IX_WeightFactor_AplikasiId",
                table: "WeightFactor");
        }
    }
}
