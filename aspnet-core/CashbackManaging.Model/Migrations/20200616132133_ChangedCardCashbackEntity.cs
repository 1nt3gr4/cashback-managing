using Microsoft.EntityFrameworkCore.Migrations;

namespace CashbackManaging.Model.Migrations
{
    public partial class ChangedCardCashbackEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CashbackPercent",
                table: "CardMccCodeCashbacks");

            migrationBuilder.AddColumn<decimal>(
                name: "CashbackPercentFrom",
                table: "CardMccCodeCashbacks",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CashbackPercentTo",
                table: "CardMccCodeCashbacks",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CashbackPercentFrom",
                table: "CardMccCodeCashbacks");

            migrationBuilder.DropColumn(
                name: "CashbackPercentTo",
                table: "CardMccCodeCashbacks");

            migrationBuilder.AddColumn<decimal>(
                name: "CashbackPercent",
                table: "CardMccCodeCashbacks",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
