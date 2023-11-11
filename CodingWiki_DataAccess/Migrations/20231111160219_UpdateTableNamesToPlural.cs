using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableNamesToPlural : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBookMap_Authors_Author_Id",
                table: "AuthorBookMap");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBookMap_Books_Book_Id",
                table: "AuthorBookMap");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_AuthorBookMap_Fluent_Author_Author_Id",
                table: "Fluent_AuthorBookMap");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_AuthorBookMap_Fluent_Book_Book_Id",
                table: "Fluent_AuthorBookMap");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Book_Fluent_Publisher_Publisher_Id",
                table: "Fluent_Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookDetails_Fluent_Book_Book_Id",
                table: "Fluent_BookDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_Publisher",
                table: "Fluent_Publisher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_Book",
                table: "Fluent_Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_AuthorBookMap",
                table: "Fluent_AuthorBookMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_Author",
                table: "Fluent_Author");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorBookMap",
                table: "AuthorBookMap");

            migrationBuilder.RenameTable(
                name: "Fluent_Publisher",
                newName: "Fluent_Publishers");

            migrationBuilder.RenameTable(
                name: "Fluent_Book",
                newName: "Fluent_Books");

            migrationBuilder.RenameTable(
                name: "Fluent_AuthorBookMap",
                newName: "Fluent_AuthorBookMaps");

            migrationBuilder.RenameTable(
                name: "Fluent_Author",
                newName: "Fluent_Authors");

            migrationBuilder.RenameTable(
                name: "AuthorBookMap",
                newName: "AuthorBookMaps");

            migrationBuilder.RenameIndex(
                name: "IX_Fluent_Book_Publisher_Id",
                table: "Fluent_Books",
                newName: "IX_Fluent_Books_Publisher_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Fluent_AuthorBookMap_Book_Id",
                table: "Fluent_AuthorBookMaps",
                newName: "IX_Fluent_AuthorBookMaps_Book_Id");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBookMap_Book_Id",
                table: "AuthorBookMaps",
                newName: "IX_AuthorBookMaps_Book_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_Publishers",
                table: "Fluent_Publishers",
                column: "Publisher_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_Books",
                table: "Fluent_Books",
                column: "BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_AuthorBookMaps",
                table: "Fluent_AuthorBookMaps",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_Authors",
                table: "Fluent_Authors",
                column: "Author_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorBookMaps",
                table: "AuthorBookMaps",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBookMaps_Authors_Author_Id",
                table: "AuthorBookMaps",
                column: "Author_Id",
                principalTable: "Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBookMaps_Books_Book_Id",
                table: "AuthorBookMaps",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_AuthorBookMaps_Fluent_Authors_Author_Id",
                table: "Fluent_AuthorBookMaps",
                column: "Author_Id",
                principalTable: "Fluent_Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_AuthorBookMaps_Fluent_Books_Book_Id",
                table: "Fluent_AuthorBookMaps",
                column: "Book_Id",
                principalTable: "Fluent_Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookDetails_Fluent_Books_Book_Id",
                table: "Fluent_BookDetails",
                column: "Book_Id",
                principalTable: "Fluent_Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Books_Fluent_Publishers_Publisher_Id",
                table: "Fluent_Books",
                column: "Publisher_Id",
                principalTable: "Fluent_Publishers",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBookMaps_Authors_Author_Id",
                table: "AuthorBookMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorBookMaps_Books_Book_Id",
                table: "AuthorBookMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_AuthorBookMaps_Fluent_Authors_Author_Id",
                table: "Fluent_AuthorBookMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_AuthorBookMaps_Fluent_Books_Book_Id",
                table: "Fluent_AuthorBookMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookDetails_Fluent_Books_Book_Id",
                table: "Fluent_BookDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Books_Fluent_Publishers_Publisher_Id",
                table: "Fluent_Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_Publishers",
                table: "Fluent_Publishers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_Books",
                table: "Fluent_Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_Authors",
                table: "Fluent_Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_AuthorBookMaps",
                table: "Fluent_AuthorBookMaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuthorBookMaps",
                table: "AuthorBookMaps");

            migrationBuilder.RenameTable(
                name: "Fluent_Publishers",
                newName: "Fluent_Publisher");

            migrationBuilder.RenameTable(
                name: "Fluent_Books",
                newName: "Fluent_Book");

            migrationBuilder.RenameTable(
                name: "Fluent_Authors",
                newName: "Fluent_Author");

            migrationBuilder.RenameTable(
                name: "Fluent_AuthorBookMaps",
                newName: "Fluent_AuthorBookMap");

            migrationBuilder.RenameTable(
                name: "AuthorBookMaps",
                newName: "AuthorBookMap");

            migrationBuilder.RenameIndex(
                name: "IX_Fluent_Books_Publisher_Id",
                table: "Fluent_Book",
                newName: "IX_Fluent_Book_Publisher_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Fluent_AuthorBookMaps_Book_Id",
                table: "Fluent_AuthorBookMap",
                newName: "IX_Fluent_AuthorBookMap_Book_Id");

            migrationBuilder.RenameIndex(
                name: "IX_AuthorBookMaps_Book_Id",
                table: "AuthorBookMap",
                newName: "IX_AuthorBookMap_Book_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_Publisher",
                table: "Fluent_Publisher",
                column: "Publisher_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_Book",
                table: "Fluent_Book",
                column: "BookId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_Author",
                table: "Fluent_Author",
                column: "Author_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_AuthorBookMap",
                table: "Fluent_AuthorBookMap",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuthorBookMap",
                table: "AuthorBookMap",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBookMap_Authors_Author_Id",
                table: "AuthorBookMap",
                column: "Author_Id",
                principalTable: "Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorBookMap_Books_Book_Id",
                table: "AuthorBookMap",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_AuthorBookMap_Fluent_Author_Author_Id",
                table: "Fluent_AuthorBookMap",
                column: "Author_Id",
                principalTable: "Fluent_Author",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_AuthorBookMap_Fluent_Book_Book_Id",
                table: "Fluent_AuthorBookMap",
                column: "Book_Id",
                principalTable: "Fluent_Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Book_Fluent_Publisher_Publisher_Id",
                table: "Fluent_Book",
                column: "Publisher_Id",
                principalTable: "Fluent_Publisher",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookDetails_Fluent_Book_Book_Id",
                table: "Fluent_BookDetails",
                column: "Book_Id",
                principalTable: "Fluent_Book",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
