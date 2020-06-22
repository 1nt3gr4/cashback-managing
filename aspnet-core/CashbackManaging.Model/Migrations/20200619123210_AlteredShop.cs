using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace CashbackManaging.Model.Migrations
{
    public partial class AlteredShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoordsX",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "CoordsY",
                table: "Shops");

            migrationBuilder.AddColumn<decimal>(
                name: "Lattitude",
                table: "Shops",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Shops",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "CardMccCodeCashbacks",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsForChoice",
                table: "CardMccCodeCashbacks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CardMccGroup",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    CardId = table.Column<int>(nullable: true),
                    CashbackPercentFrom = table.Column<decimal>(nullable: true),
                    CashbackPercentTo = table.Column<decimal>(nullable: true),
                    IsForChoice = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardMccGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardMccGroup_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardMccCodeCashbacks_GroupId",
                table: "CardMccCodeCashbacks",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_CardMccGroup_CardId",
                table: "CardMccGroup",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardMccCodeCashbacks_CardMccGroup_GroupId",
                table: "CardMccCodeCashbacks",
                column: "GroupId",
                principalTable: "CardMccGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardMccCodeCashbacks_CardMccGroup_GroupId",
                table: "CardMccCodeCashbacks");

            migrationBuilder.DropTable(
                name: "CardMccGroup");

            migrationBuilder.DropIndex(
                name: "IX_CardMccCodeCashbacks_GroupId",
                table: "CardMccCodeCashbacks");

            migrationBuilder.DropColumn(
                name: "Lattitude",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Shops");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "CardMccCodeCashbacks");

            migrationBuilder.DropColumn(
                name: "IsForChoice",
                table: "CardMccCodeCashbacks");

            migrationBuilder.AddColumn<decimal>(
                name: "CoordsX",
                table: "Shops",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CoordsY",
                table: "Shops",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
