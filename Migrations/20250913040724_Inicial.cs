using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlayerRegistrations.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Match_Players_Player2Id",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Players_PlayerId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Players_PlayerTurnId",
                table: "Match");

            migrationBuilder.DropForeignKey(
                name: "FK_Match_Players_WinnerId",
                table: "Match");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Match",
                table: "Match");

            migrationBuilder.RenameTable(
                name: "Match",
                newName: "Matches");

            migrationBuilder.RenameIndex(
                name: "IX_Match_WinnerId",
                table: "Matches",
                newName: "IX_Matches_WinnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Match_PlayerTurnId",
                table: "Matches",
                newName: "IX_Matches_PlayerTurnId");

            migrationBuilder.RenameIndex(
                name: "IX_Match_PlayerId",
                table: "Matches",
                newName: "IX_Matches_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Match_Player2Id",
                table: "Matches",
                newName: "IX_Matches_Player2Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matches",
                table: "Matches",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_Player2Id",
                table: "Matches",
                column: "Player2Id",
                principalTable: "Players",
                principalColumn: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_PlayerId",
                table: "Matches",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_PlayerTurnId",
                table: "Matches",
                column: "PlayerTurnId",
                principalTable: "Players",
                principalColumn: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matches_Players_WinnerId",
                table: "Matches",
                column: "WinnerId",
                principalTable: "Players",
                principalColumn: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_Player2Id",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_PlayerId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_PlayerTurnId",
                table: "Matches");

            migrationBuilder.DropForeignKey(
                name: "FK_Matches_Players_WinnerId",
                table: "Matches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Matches",
                table: "Matches");

            migrationBuilder.RenameTable(
                name: "Matches",
                newName: "Match");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_WinnerId",
                table: "Match",
                newName: "IX_Match_WinnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_PlayerTurnId",
                table: "Match",
                newName: "IX_Match_PlayerTurnId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_PlayerId",
                table: "Match",
                newName: "IX_Match_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Matches_Player2Id",
                table: "Match",
                newName: "IX_Match_Player2Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Match",
                table: "Match",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Players_Player2Id",
                table: "Match",
                column: "Player2Id",
                principalTable: "Players",
                principalColumn: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Players_PlayerId",
                table: "Match",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "PlayerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Players_PlayerTurnId",
                table: "Match",
                column: "PlayerTurnId",
                principalTable: "Players",
                principalColumn: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Match_Players_WinnerId",
                table: "Match",
                column: "WinnerId",
                principalTable: "Players",
                principalColumn: "PlayerId");
        }
    }
}
