using Microsoft.EntityFrameworkCore.Migrations;

namespace Dawam.DAL.Data.Migrations
{
    public partial class AddingWaqfAdminNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminNotes",
                table: "Waqfs",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminNotes",
                table: "Waqfs");
        }
    }
}
