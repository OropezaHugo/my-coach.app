namespace Core.ResponseDTOs;

public class UserResponseDTO
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public  required string Email { get; set; }
    public required string Endpoint { get; set; }
    public required string P256dh { get; set; }
    public required string Auth { get; set; }
    public required string AvatarUrl { get; set; } = string.Empty;
    public DateOnly Birthday { get; set; }
    public int RoleId { get; set; }
}