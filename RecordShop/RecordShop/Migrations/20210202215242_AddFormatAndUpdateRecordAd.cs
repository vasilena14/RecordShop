using Microsoft.EntityFrameworkCore.Migrations;

namespace RecordShop.Migrations
{
    public partial class AddFormatAndUpdateRecordAd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormatID",
                table: "RecordAds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Formats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formats", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecordAds_FormatID",
                table: "RecordAds",
                column: "FormatID");

            migrationBuilder.AddForeignKey(
                name: "FK_RecordAds_Formats_FormatID",
                table: "RecordAds",
                column: "FormatID",
                principalTable: "Formats",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecordAds_Formats_FormatID",
                table: "RecordAds");

            migrationBuilder.DropTable(
                name: "Formats");

            migrationBuilder.DropIndex(
                name: "IX_RecordAds_FormatID",
                table: "RecordAds");

            migrationBuilder.DropColumn(
                name: "FormatID",
                table: "RecordAds");
        }
    }
}
