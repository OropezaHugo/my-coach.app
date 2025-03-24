using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.GamificationEntities;

public class NotificationSubscription: BaseEntity
{
    public required string Endpoint { get; set; }
    public required string P256dh { get; set; }
    public required string Auth { get; set; }
    
    
    public required int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
}