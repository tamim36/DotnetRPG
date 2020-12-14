using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class UserCharacterOneToManyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "characters",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_characters_UserId",
                table: "characters",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_characters_users_UserId",
                table: "characters",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_characters_users_UserId",
                table: "characters");

            migrationBuilder.DropIndex(
                name: "IX_characters_UserId",
                table: "characters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "characters");
        }
    }
}
