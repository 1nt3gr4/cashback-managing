using Microsoft.EntityFrameworkCore.Migrations;

namespace CashbackManaging.Model.Migrations
{
    public partial class ChangedCardEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DefaultCashbackPercent",
                table: "Cards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefaultCashbackPercent",
                table: "Cards");
        }
    }
}
