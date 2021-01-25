using Microsoft.EntityFrameworkCore.Migrations;

namespace SiTiPetro.Migrations.Aplikasi
{
    public partial class AddAplikasiId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aplikasi_RencanaTimeline_rencanaTimelineId",
                table: "Aplikasi");

            migrationBuilder.DropIndex(
                name: "IX_Aplikasi_rencanaTimelineId",
                table: "Aplikasi");

            migrationBuilder.DropColumn(
                name: "rencanaTimelineId",
                table: "Aplikasi");

            migrationBuilder.AddColumn<int>(
                name: "AplikasiId",
                table: "RencanaTimeline",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RencanaTimeline_AplikasiId",
                table: "RencanaTimeline",
                column: "AplikasiId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RencanaTimeline_Aplikasi_AplikasiId",
                table: "RencanaTimeline",
                column: "AplikasiId",
                principalTable: "Aplikasi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RencanaTimeline_Aplikasi_AplikasiId",
                table: "RencanaTimeline");

            migrationBuilder.DropIndex(
                name: "IX_RencanaTimeline_AplikasiId",
                table: "RencanaTimeline");

            migrationBuilder.DropColumn(
                name: "AplikasiId",
                table: "RencanaTimeline");

            migrationBuilder.AddColumn<int>(
                name: "rencanaTimelineId",
                table: "Aplikasi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Aplikasi_rencanaTimelineId",
                table: "Aplikasi",
                column: "rencanaTimelineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Aplikasi_RencanaTimeline_rencanaTimelineId",
                table: "Aplikasi",
                column: "rencanaTimelineId",
                principalTable: "RencanaTimeline",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
