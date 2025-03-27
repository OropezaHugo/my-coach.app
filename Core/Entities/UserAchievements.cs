using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.GamificationEntities;

namespace Core.Entities;

public class UserAchievements: BaseEntity
{
    public required int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
    public required int AchievementId { get; set; }
    [ForeignKey(nameof(AchievementId))]
    public Achievement? Achievement { get; set; }
    
    public int AchievementStepsProgress { get; set; }
    public int AchievementActualLevel { get; set; }
    public bool IsBadge { get; set; }
}