namespace Api.ResponseDTOs;

public class UserResponseDTO
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public  required string Email { get; set; }
    public required string Password { get; set; }
    public string AvatarUrl { get; set; } = string.Empty;
    public DateOnly Birthday { get; set; }
    public int RoleId { get; set; }
}