using Microsoft.EntityFrameworkCore.Migrations;

namespace SiTiPetro.Migrations.Aplikasi
{
    public partial class addRealisasiInRencanaTimeline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RealisasiBrdDate1",
                table: "RencanaTimeline",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealisasiBrdDate2",
                table: "RencanaTimeline",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealisasiClosingDate1",
                table: "RencanaTimeline",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealisasiClosingDate2",
                table: "RencanaTimeline",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealisasiDesainPrototypeDate1",
                table: "RencanaTimeline",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealisasiDesainPrototypeDate2",
                table: "RencanaTimeline",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealisasiEutDate1",
                table: "RencanaTimeline",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealisasiEutDate2",
                table: "RencanaTimeline",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealisasiFinalBrdDate1",
                table: "RencanaTimeline",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealisasiFinalBrdDate2",
                table: "RencanaTimeline",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealisasiGoLiveDate1",
                table: "RencanaTimeline",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealisasiGoLiveDate2",
                table: "RencanaTimeline",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealisasiPengadaanDate1",
                table: "RencanaTimeline",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealisasiPengadaanDate2",
                table: "RencanaTimeline",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealisasiPengembanganDate1",
                table: "RencanaTimeline",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealisasiPengembanganDate2",
                table: "RencanaTimeline",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealisasiSupportDate1",
                table: "RencanaTimeline",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealisasiSupportDate2",
                table: "RencanaTimeline",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealisasiTestingDate1",
                table: "RencanaTimeline",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RealisasiTestingDate2",
                table: "RencanaTimeline",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "RealisasiBrdDate1",
                table: "RencanaTimeline");

            migrationBuilder.DropColumn(
                name: "RealisasiBrdDate2",
                table: "RencanaTimeline");

            migrationBuilder.DropColumn(
                name: "RealisasiClosingDate1",
                table: "RencanaTimeline");

            migrationBuilder.DropColumn(
                name: "RealisasiClosingDate2",
                table: "RencanaTimeline");

            migrationBuilder.DropColumn(
                name: "RealisasiDesainPrototypeDate1",
                table: "RencanaTimeline");

            migrationBuilder.DropColumn(
                name: "RealisasiDesainPrototypeDate2",
                table: "RencanaTimeline");

            migrationBuilder.DropColumn(
                name: "RealisasiEutDate1",
                table: "RencanaTimeline");

            migrationBuilder.DropColumn(
                name: "RealisasiEutDate2",
                table: "RencanaTimeline");

            migrationBuilder.DropColumn(
                name: "RealisasiFinalBrdDate1",
                table: "RencanaTimeline");

            migrationBuilder.DropColumn(
                name: "RealisasiFinalBrdDate2",
                table: "RencanaTimeline");

            migrationBuilder.DropColumn(
                name: "RealisasiGoLiveDate1",
                table: "RencanaTimeline");

            migrationBuilder.DropColumn(
                name: "RealisasiGoLiveDate2",
                table: "RencanaTimeline");

            migrationBuilder.DropColumn(
                name: "RealisasiPengadaanDate1",
                table: "RencanaTimeline");

            migrationBuilder.DropColumn(
                name: "RealisasiPengadaanDate2",
                table: "RencanaTimeline");

            migrationBuilder.DropColumn(
                name: "RealisasiPengembanganDate1",
                table: "RencanaTimeline");

            migrationBuilder.DropColumn(
                name: "RealisasiPengembanganDate2",
                table: "RencanaTimeline");

            migrationBuilder.DropColumn(
                name: "RealisasiSupportDate1",
                table: "RencanaTimeline");

            migrationBuilder.DropColumn(
                name: "RealisasiSupportDate2",
                table: "RencanaTimeline");

            migrationBuilder.DropColumn(
                name: "RealisasiTestingDate1",
                table: "RencanaTimeline");

            migrationBuilder.DropColumn(
                name: "RealisasiTestingDate2",
                table: "RencanaTimeline");
        }
    }
}
