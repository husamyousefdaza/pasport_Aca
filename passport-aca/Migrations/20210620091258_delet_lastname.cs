using Microsoft.EntityFrameworkCore.Migrations;

namespace passport_aca.Migrations
{
    public partial class delet_lastname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "last_name",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "home",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "home",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "last_name",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
