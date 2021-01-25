using Microsoft.EntityFrameworkCore.Migrations;

namespace SiTiPetro.Migrations.Aplikasi
{
    public partial class AddAplikasiIdInRencanaTimeline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aplikasi_RencanaTimeline_rencanaTimelineId",
                table: "Aplikasi");

            migrationBuilder.DropTable(
                name: "RencanaTimeline");

            migrationBuilder.DropIndex(
                name: "IX_Aplikasi_rencanaTimelineId",
                table: "Aplikasi");

            migrationBuilder.DropColumn(
                name: "rencanaTimelineId",
                table: "Aplikasi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "rencanaTimelineId",
                table: "Aplikasi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RencanaTimeline",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrdDate1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrdDate2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosingDate1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClosingDate2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesainPrototypeDate1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesainPrototypeDate2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EutDate1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EutDate2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalBrdDate1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinalBrdDate2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoLiveDate1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoLiveDate2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PengadaanDate1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PengadaanDate2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PengembanganDate1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PengembanganDate2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupportDate1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupportDate2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestingDate1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TestingDate2 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RencanaTimeline", x => x.Id);
                });

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
