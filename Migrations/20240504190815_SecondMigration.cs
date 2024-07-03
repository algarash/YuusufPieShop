using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YuusufPieShop.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LongDesic",
                table: "Pies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShortDesic",
                table: "Pies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LongDesic",
                table: "Pies");

            migrationBuilder.DropColumn(
                name: "ShortDesic",
                table: "Pies");
        }
    }
}
