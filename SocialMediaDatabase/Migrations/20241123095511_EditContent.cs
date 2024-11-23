using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialMediaDatabase.Migrations
{
    /// <inheritdoc />
    public partial class EditContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "publishAt",
                table: "Posts",
                newName: "PublishAt");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "Posts",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Posts",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PublishAt",
                table: "Posts",
                newName: "publishAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Posts",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Posts",
                newName: "Content");
        }
    }
}
