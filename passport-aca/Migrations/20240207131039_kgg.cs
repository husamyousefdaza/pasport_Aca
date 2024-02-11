using Microsoft.EntityFrameworkCore.Migrations;

namespace passport_aca.Migrations
{
    public partial class kgg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "mailid",
                table: "History",
                newName: "transactionid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "transactionid",
                table: "History",
                newName: "mailid");
        }
    }
}
