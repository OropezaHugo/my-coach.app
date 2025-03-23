using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddExerciseAchievementRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExerciseId",
                table: "Achievements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_ExerciseId",
                table: "Achievements",
                column: "ExerciseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Achievements_Exercises_ExerciseId",
                table: "Achievements",
                column: "ExerciseId",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Achievements_Exercises_ExerciseId",
                table: "Achievements");

            migrationBuilder.DropIndex(
                name: "IX_Achievements_ExerciseId",
                table: "Achievements");

            migrationBuilder.DropColumn(
                name: "ExerciseId",
                table: "Achievements");
        }
    }
}
