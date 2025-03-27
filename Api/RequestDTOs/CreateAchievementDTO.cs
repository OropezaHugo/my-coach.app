using Core.Entities.GamificationEntities;

namespace Api.RequestDTOs;

public class CreateAchievementDTO
{
    public required string AchievementName { get; set; }
    public required string AchievementImage { get; set; }
    public required string ObtainingDescription { get; set; }
    public List<int> AchievementStepsPerLevel { get; set; } = new List<int>();
    
    public required AchievementType AchievementType { get; set; }
    public required int ExerciseId { get; set; }
}