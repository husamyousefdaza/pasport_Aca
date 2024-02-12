using Microsoft.EntityFrameworkCore.Migrations;

namespace passport_aca.Migrations
{
    public partial class jdhsj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Validity",
                table: "Administrator");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Validity",
                table: "Administrator",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
