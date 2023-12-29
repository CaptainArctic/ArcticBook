using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArcticBook.Migrations
{
    public partial class updateddb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookId",
                table: "Book");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
