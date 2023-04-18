using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookWeb.Migrations
{
    /// <inheritdoc />
    public partial class updateddbcontextv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavourites_AspNetUsers_UserId",
                table: "UserFavourites");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavourites_Books_BookId",
                table: "UserFavourites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavourites",
                table: "UserFavourites");

            migrationBuilder.RenameTable(
                name: "UserFavourites",
                newName: "UserFavorites");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavourites_UserId",
                table: "UserFavorites",
                newName: "IX_UserFavorites_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavourites_BookId",
                table: "UserFavorites",
                newName: "IX_UserFavorites_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavorites",
                table: "UserFavorites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavorites_AspNetUsers_UserId",
                table: "UserFavorites",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavorites_Books_BookId",
                table: "UserFavorites",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavorites_AspNetUsers_UserId",
                table: "UserFavorites");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavorites_Books_BookId",
                table: "UserFavorites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavorites",
                table: "UserFavorites");

            migrationBuilder.RenameTable(
                name: "UserFavorites",
                newName: "UserFavourites");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavorites_UserId",
                table: "UserFavourites",
                newName: "IX_UserFavourites_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavorites_BookId",
                table: "UserFavourites",
                newName: "IX_UserFavourites_BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavourites",
                table: "UserFavourites",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavourites_AspNetUsers_UserId",
                table: "UserFavourites",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavourites_Books_BookId",
                table: "UserFavourites",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
