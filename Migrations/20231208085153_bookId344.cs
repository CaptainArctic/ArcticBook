using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArcticBook.Migrations
{
    public partial class bookId344 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Book");
        }
    }
}
