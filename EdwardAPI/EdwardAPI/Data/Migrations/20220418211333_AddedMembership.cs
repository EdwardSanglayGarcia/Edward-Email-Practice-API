using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EdwardAPI.Data.Migrations
{
    public partial class AddedMembership : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Membership",
                table: "Mails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Membership",
                table: "Mails");
        }
    }
}
