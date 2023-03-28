using Microsoft.EntityFrameworkCore.Migrations;

namespace Dawam.DAL.Data.Migrations
{
    public partial class RemovingActivityIdTypeIdcolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Waqfs");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Waqfs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Waqfs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Waqfs",
                type: "int",
                nullable: true);
        }
    }
}
