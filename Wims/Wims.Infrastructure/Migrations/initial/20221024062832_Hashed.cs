using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wims.Infrastructure.Migrations.initial
{
    public partial class Hashed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "dbo",
                table: "User",
                type: "nvarchar(256)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "dbo",
                table: "User",
                type: "nvarchar(16)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");
        }
    }
}
