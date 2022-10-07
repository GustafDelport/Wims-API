using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wims.Infrastructure.Migrations.initial
{
    public partial class ProdMinThresh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinThreshold",
                schema: "dbo",
                table: "Category");

            migrationBuilder.AddColumn<int>(
                name: "MinThreshold",
                schema: "dbo",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinThreshold",
                schema: "dbo",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "MinThreshold",
                schema: "dbo",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
