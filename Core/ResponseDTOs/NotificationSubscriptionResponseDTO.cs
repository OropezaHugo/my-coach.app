namespace Core.ResponseDTOs;

public class NotificationSubscriptionResponseDTO
{
    public int Id { get; set; }
    public required string Endpoint { get; set; }
    public required string P256dh { get; set; }
    public required string Auth { get; set; }
    public int UserId { get; set; }
}