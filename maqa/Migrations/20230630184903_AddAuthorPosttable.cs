using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace maqa.Migrations
{
    public partial class AddAuthorPosttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorPost",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Posttitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostDiscription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddeddDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorPost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorPost_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorPost_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPost_AuthorId",
                table: "AuthorPost",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPost_CategoryId",
                table: "AuthorPost",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorPost");
        }
    }
}
