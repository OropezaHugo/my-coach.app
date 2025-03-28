namespace Core.ResponseDTOs;

public class UserResponseDTO
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public DateOnly Birthday { get; set; }
    public int RoleId { get; set; }
    public int AvatarId { get; set; }
    public required string AvatarUrl { get; set; }
}