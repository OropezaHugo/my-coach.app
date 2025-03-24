namespace Api.RequestDTOs;

public class CreateNotificationSubscriptionDTO
{
    public required string Endpoint { get; set; }
    public required string P256dh { get; set; }
    public required string Auth { get; set; }
    public required int UserId { get; set; }
}