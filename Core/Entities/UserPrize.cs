using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class UserPrize: BaseEntity
{
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
    
    public int PrizeId { get; set; }
    [ForeignKey(nameof(PrizeId))]
    public Prize? Prize { get; set; }
}