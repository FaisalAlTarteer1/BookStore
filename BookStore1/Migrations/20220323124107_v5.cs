using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStore1.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_authorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_categoryId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_authorId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_categoryId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "authorId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Author_id",
                table: "Books",
                column: "Author_id");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Categoy_id",
                table: "Books",
                column: "Categoy_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_Author_id",
                table: "Books",
                column: "Author_id",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_Categoy_id",
                table: "Books",
                column: "Categoy_id",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_Author_id",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_Categoy_id",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_Author_id",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_Categoy_id",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "authorId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_authorId",
                table: "Books",
                column: "authorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_categoryId",
                table: "Books",
                column: "categoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_authorId",
                table: "Books",
                column: "authorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_categoryId",
                table: "Books",
                column: "categoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
