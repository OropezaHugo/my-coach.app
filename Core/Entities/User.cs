using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.GamificationEntities;

namespace Core.Entities;

public class User: BaseEntity
{
    public required string Name { get; set; }
    public  required string Email { get; set; }
    public DateOnly Birthday { get; set; }
    
    public int RoleId { get; set; }
    [ForeignKey(nameof(RoleId))]
    public Role? Role { get; set; }
    
    public int AvatarId { get; set; }
    [ForeignKey(nameof(AvatarId))]
    public Avatar Avatar { get; set; }

    public List<UserTrainingPlans> UserTrainingPlans { get; set; } = new List<UserTrainingPlans>();
    public List<UserDiet> UserDiets { get; set; } = new List<UserDiet>();
    public List<UserPrize> UserPrizes { get; set; } = new List<UserPrize>();
    public List<UserAchievements> UserAchievements { get; set; } = new List<UserAchievements>();
}