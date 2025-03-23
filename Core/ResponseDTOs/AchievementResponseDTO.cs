namespace Core.ResponseDTOs;

public class AchievementResponseDTO
{
    public int Id { get; set; }
    public required string AchievementName { get; set; }
    public required string AchievementImage { get; set; }
    public required string ObtainingDescription { get; set; }
    public List<int> AchievementStepsPerLevel { get; set; } = new List<int>();
    public required int ExerciseId { get; set; }
}