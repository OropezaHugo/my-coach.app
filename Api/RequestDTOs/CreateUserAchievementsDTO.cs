namespace Api.RequestDTOs;

public class CreateUserAchievementsDTO
{
    public required string UserId { get; set; }
    public required string AchievementId { get; set; }
    public int AchievementStepsProgress { get; set; }
    public int AchievementActualLevel { get; set; }
}