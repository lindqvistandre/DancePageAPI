using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DancePage.Migrations
{
    public partial class innit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Gifsinfos",
                columns: table => new
                {
                    GifsInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gifsinfos", x => x.GifsInfoId);
                    table.ForeignKey(
                        name: "FK_Gifsinfos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 1, "Test@test.se", "Andre", "Lindqvist", "332211" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 2, "Test2@test.se", "Andre2", "Lindqvist", "332211" });

            migrationBuilder.InsertData(
                table: "Gifsinfos",
                columns: new[] { "GifsInfoId", "Artist", "Comment", "Link", "UserId" },
                values: new object[] { 1, "hej", "Comment Test", "http://jalla.se", 1 });

            migrationBuilder.InsertData(
                table: "Gifsinfos",
                columns: new[] { "GifsInfoId", "Artist", "Comment", "Link", "UserId" },
                values: new object[] { 2, "artist2", "Comment Test2", "http://jalla2.se", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Gifsinfos_UserId",
                table: "Gifsinfos",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gifsinfos");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
