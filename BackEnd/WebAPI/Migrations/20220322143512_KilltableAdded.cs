using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class KilltableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KillsTableId",
                table: "User",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_User_KillsTableId",
                table: "User",
                column: "KillsTableId");

            migrationBuilder.CreateIndex(
                name: "IX_KillsTable_UserId",
                table: "KillsTable",
                column: "UserId");

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
                name: "FK_User_KillsTable_KillsTableId",
                table: "User");

            migrationBuilder.DropTable(
                name: "KillsTable");

            migrationBuilder.DropIndex(
                name: "IX_User_KillsTableId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "KillsTableId",
                table: "User");
        }
    }
}
