using Microsoft.EntityFrameworkCore.Migrations;

namespace passport_aca.Migrations
{
    public partial class hh : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reason_for_booking",
                table: "transactions");

            migrationBuilder.AlterColumn<int>(
                name: "nationality_number",
                table: "transactions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "nationality_number",
                table: "transactions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "reason_for_booking",
                table: "transactions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
