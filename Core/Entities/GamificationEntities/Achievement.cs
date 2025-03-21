namespace Core.Entities.GamificationEntities;

public class Achievement: BaseEntity
{
    public required string AchievementName { get; set; }
    public required string AchievementImage { get; set; }
    public required string ObtainingDescription { get; set; }
    
    // index 0 = steps from level 0 to 1
    public List<int> AchievementStepsPerLevel { get; set; } = new List<int>();
    public List<UserAchievements> UserAchievements { get; set; } = new List<UserAchievements>();
}