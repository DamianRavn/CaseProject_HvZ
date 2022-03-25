using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class FinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameState = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsHuman = table.Column<bool>(type: "bit", nullable: false),
                    IsPatientZero = table.Column<bool>(type: "bit", nullable: false),
                    BiteCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    GameId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    KeycloakId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KillsTableId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KillsTable",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KillsTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KillsTable_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "FirstName", "KeycloakId", "KillsTableId", "LastName", "UserName" },
                values: new object[,]
                {
                    { 1, "James", null, null, "Smith", "captain" },
                    { 2, "James", null, null, "Glass", "kid" },
                    { 3, "Cameron", null, null, "Webcam", "Luffy" },
                    { 4, "Face", null, null, "Off", "the" },
                    { 5, "Code", null, null, "Name", "pirate" },
                    { 6, "Seven", null, null, "Eight", "king" },
                    { 7, "Half", null, null, "Dan", "Water Law" }
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, 6 });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 2, 7 });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AdminId", "GameState", "Name" },
                values: new object[] { 1, 1, 1, "Game" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AdminId", "GameState", "Name" },
                values: new object[] { 3, 1, 2, "This Game" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AdminId", "GameState", "Name" },
                values: new object[] { 2, 2, 0, "Some Game" });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "Id", "BiteCode", "GameId", "IsHuman", "IsPatientZero", "UserId" },
                values: new object[,]
                {
                    { 1, "Rando", 1, true, false, 1 },
                    { 2, "mlyge", 1, true, true, 2 },
                    { 5, "e", 3, true, false, 5 },
                    { 3, "nerat", 2, false, true, 3 },
                    { 4, "edCod", 2, true, false, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_UserId",
                table: "Admin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_AdminId",
                table: "Games",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_KillsTable_UserId",
                table: "KillsTable",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_GameId",
                table: "Players",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserId",
                table: "Players",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_KillsTableId",
                table: "User",
                column: "KillsTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Admin_AdminId",
                table: "Games",
                column: "AdminId",
                principalTable: "Admin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_User_UserId",
                table: "Players",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_KillsTable_KillsTableId",
                table: "User",
                column: "KillsTableId",
                principalTable: "KillsTable",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KillsTable_User_UserId",
                table: "KillsTable");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "KillsTable");
        }
    }
}
