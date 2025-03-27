using Core.Entities.GamificationEntities;

namespace Core.ResponseDTOs;

public class UserAchievementContentDTO
{
    
    public int Id { get; set; }
    public required int UserId { get; set; }
    public required int AchievementId { get; set; }
    public int AchievementStepsProgress { get; set; }
    public int AchievementActualLevel { get; set; }
    public bool IsBadge { get; set; }
    
    
    public required string AchievementName { get; set; }
    public required string AchievementImage { get; set; }
    public required string ObtainingDescription { get; set; }
    public required AchievementType AchievementType { get; set; }
    public List<int> AchievementStepsPerLevel { get; set; } = new List<int>();
    public required int ExerciseId { get; set; }
}