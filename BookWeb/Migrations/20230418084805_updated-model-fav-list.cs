using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookWeb.Migrations
{
    /// <inheritdoc />
    public partial class updatedmodelfavlist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavourites_AspNetUsers_UserId",
                table: "UserFavourites");

            migrationBuilder.DropColumn(
                name: "BookIdt",
                table: "UserFavourites");

            migrationBuilder.DropColumn(
                name: "UserIdt",
                table: "UserFavourites");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserFavourites",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavourites_AspNetUsers_UserId",
                table: "UserFavourites",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavourites_AspNetUsers_UserId",
                table: "UserFavourites");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserFavourites",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "BookIdt",
                table: "UserFavourites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserIdt",
                table: "UserFavourites",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavourites_AspNetUsers_UserId",
                table: "UserFavourites",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
