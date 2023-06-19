using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SignalRAssignment.Migrations
{
    public partial class updateAccountType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountType",
                table: "Account");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountType",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
