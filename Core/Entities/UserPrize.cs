using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.GamificationEntities;

namespace Core.Entities;

public class UserPrize: BaseEntity
{
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
    
    public int PrizeId { get; set; }
    [ForeignKey(nameof(PrizeId))]
    public Prize? Prize { get; set; }
    
    public DateOnly ObtainedDate { get; set; }
}