namespace Core.ResponseDTOs;

public class UserAchievementsResponseDTO
{
    public int Id { get; set; }
    public required int UserId { get; set; }
    public required int AchievementId { get; set; }
    public int AchievementStepsProgress { get; set; }
    public int AchievementActualLevel { get; set; }
}