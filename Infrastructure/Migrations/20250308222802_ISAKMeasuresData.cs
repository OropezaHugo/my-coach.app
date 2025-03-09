using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ISAKMeasuresData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IsakMeasures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TricepsMm = table.Column<float>(type: "real", nullable: false),
                    SubscapularMm = table.Column<float>(type: "real", nullable: false),
                    BicepsMm = table.Column<float>(type: "real", nullable: false),
                    IliacCrestMm = table.Column<float>(type: "real", nullable: false),
                    SupraespinalMm = table.Column<float>(type: "real", nullable: false),
                    AbdominalMm = table.Column<float>(type: "real", nullable: false),
                    FrontThighMm = table.Column<float>(type: "real", nullable: false),
                    MedialCalfMm = table.Column<float>(type: "real", nullable: false),
                    RelaxedArmCm = table.Column<float>(type: "real", nullable: false),
                    FlexedArmCm = table.Column<float>(type: "real", nullable: false),
                    WaistCm = table.Column<float>(type: "real", nullable: false),
                    HipCm = table.Column<float>(type: "real", nullable: false),
                    MidThighCm = table.Column<float>(type: "real", nullable: false),
                    CalfCm = table.Column<float>(type: "real", nullable: false),
                    WristDiameterCm = table.Column<float>(type: "real", nullable: false),
                    ElbowDiameterCm = table.Column<float>(type: "real", nullable: false),
                    KneeDiameterCm = table.Column<float>(type: "real", nullable: false),
                    WeightKg = table.Column<float>(type: "real", nullable: false),
                    TotalHeightMts = table.Column<float>(type: "real", nullable: false),
                    WingspanCm = table.Column<float>(type: "real", nullable: false),
                    FootLengthCm = table.Column<float>(type: "real", nullable: false),
                    MeasureDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsakMeasures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IsakMeasures_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IsakMeasures_UserId",
                table: "IsakMeasures",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IsakMeasures");
        }
    }
}
