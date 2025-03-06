using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FoodFullData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "FoodAshGr",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FoodCalciumGr",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FoodCarbsGr",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FoodEnergyKcal",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FoodFatGr",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FoodFibberGr",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "FoodGroup",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "FoodHumidityGr",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FoodIronMg",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FoodPhosphorusMg",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FoodProteinGr",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "FoodSubGroup",
                table: "Foods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "FoodVitaminAMig",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FoodVitaminB1Mg",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FoodVitaminB2Mg",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FoodVitaminB3Mg",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "FoodVitaminCMg",
                table: "Foods",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoodAshGr",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodCalciumGr",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodCarbsGr",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodEnergyKcal",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodFatGr",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodFibberGr",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodGroup",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodHumidityGr",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodIronMg",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodPhosphorusMg",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodProteinGr",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodSubGroup",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodVitaminAMig",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodVitaminB1Mg",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodVitaminB2Mg",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodVitaminB3Mg",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "FoodVitaminCMg",
                table: "Foods");
        }
    }
}
