namespace Api.RequestDTOs;

public class CreateUserAchievementsDTO
{
    public required int UserId { get; set; }
    public required int AchievementId { get; set; }
    public int AchievementStepsProgress { get; set; }
    public int AchievementActualLevel { get; set; }
    public bool IsBadge { get; set; }
}