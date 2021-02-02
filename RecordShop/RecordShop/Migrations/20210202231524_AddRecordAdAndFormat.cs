using Microsoft.EntityFrameworkCore.Migrations;

namespace RecordShop.Migrations
{
    public partial class AddRecordAdAndFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "RecordAds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArtistID = table.Column<int>(nullable: false),
                    AlbumID = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    FormatID = table.Column<int>(nullable: false),
                    Genre = table.Column<string>(nullable: false),
                    SellerName = table.Column<string>(nullable: false),
                    SellerEmail = table.Column<string>(nullable: false),
                    SellerPhone = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecordAds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecordAds_Albums_AlbumID",
                        column: x => x.AlbumID,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RecordAds_Artists_ArtistID",
                        column: x => x.ArtistID,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_RecordAds_Formats_FormatID",
                        column: x => x.FormatID,
                        principalTable: "Formats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecordAds_AlbumID",
                table: "RecordAds",
                column: "AlbumID");

            migrationBuilder.CreateIndex(
                name: "IX_RecordAds_ArtistID",
                table: "RecordAds",
                column: "ArtistID");

            migrationBuilder.CreateIndex(
                name: "IX_RecordAds_FormatID",
                table: "RecordAds",
                column: "FormatID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecordAds");

            migrationBuilder.DropTable(
                name: "Formats");
        }
    }
}
