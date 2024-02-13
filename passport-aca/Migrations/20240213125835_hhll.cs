using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace passport_aca.Migrations
{
    public partial class hhll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "notice",
                table: "transactions");

            migrationBuilder.RenameColumn(
                name: "recipients_name",
                table: "transactions",
                newName: "classification");

            migrationBuilder.AddColumn<DateTime>(
                name: "picture_date",
                table: "transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "picture_date",
                table: "transactions");

            migrationBuilder.RenameColumn(
                name: "classification",
                table: "transactions",
                newName: "recipients_name");

            migrationBuilder.AddColumn<string>(
                name: "notice",
                table: "transactions",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
