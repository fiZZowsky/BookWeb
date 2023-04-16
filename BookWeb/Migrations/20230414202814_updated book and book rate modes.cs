using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookWeb.Migrations
{
    /// <inheritdoc />
    public partial class updatedbookandbookratemodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRate_AspNetUsers_UserId",
                table: "BookRate");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookRate_RateId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Books_BookId",
                table: "Comment");

            migrationBuilder.DropIndex(
                name: "IX_Books_RateId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookRate",
                table: "BookRate");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameTable(
                name: "BookRate",
                newName: "BookRates");

            migrationBuilder.RenameColumn(
                name: "RateId",
                table: "Books",
                newName: "Rating");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UserId",
                table: "Comments",
                newName: "IX_Comments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_BookId",
                table: "Comments",
                newName: "IX_Comments_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookRate_UserId",
                table: "BookRates",
                newName: "IX_BookRates_UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedDate",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "BookRates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookRates",
                table: "BookRates",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookRates_BookId",
                table: "BookRates",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRates_AspNetUsers_UserId",
                table: "BookRates",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookRates_Books_BookId",
                table: "BookRates",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Books_BookId",
                table: "Comments",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookRates_AspNetUsers_UserId",
                table: "BookRates");

            migrationBuilder.DropForeignKey(
                name: "FK_BookRates_Books_BookId",
                table: "BookRates");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Books_BookId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookRates",
                table: "BookRates");

            migrationBuilder.DropIndex(
                name: "IX_BookRates_BookId",
                table: "BookRates");

            migrationBuilder.DropColumn(
                name: "PublishedDate",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookRates");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameTable(
                name: "BookRates",
                newName: "BookRate");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Books",
                newName: "RateId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserId",
                table: "Comment",
                newName: "IX_Comment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_BookId",
                table: "Comment",
                newName: "IX_Comment_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookRates_UserId",
                table: "BookRate",
                newName: "IX_BookRate_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookRate",
                table: "BookRate",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_RateId",
                table: "Books",
                column: "RateId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookRate_AspNetUsers_UserId",
                table: "BookRate",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookRate_RateId",
                table: "Books",
                column: "RateId",
                principalTable: "BookRate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_AspNetUsers_UserId",
                table: "Comment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Books_BookId",
                table: "Comment",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");
        }
    }
}
