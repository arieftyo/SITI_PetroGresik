using Microsoft.EntityFrameworkCore.Migrations;

namespace SiTiPetro.Migrations.Aplikasi
{
    public partial class addDeveloperModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeveloperdevId",
                table: "Aplikasi",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Developers",
                columns: table => new
                {
                    devId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nama = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developers", x => x.devId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aplikasi_DeveloperdevId",
                table: "Aplikasi",
                column: "DeveloperdevId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aplikasi_Developers_DeveloperdevId",
                table: "Aplikasi",
                column: "DeveloperdevId",
                principalTable: "Developers",
                principalColumn: "devId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aplikasi_Developers_DeveloperdevId",
                table: "Aplikasi");

            migrationBuilder.DropTable(
                name: "Developers");

            migrationBuilder.DropIndex(
                name: "IX_Aplikasi_DeveloperdevId",
                table: "Aplikasi");

            migrationBuilder.DropColumn(
                name: "DeveloperdevId",
                table: "Aplikasi");
        }
    }
}
