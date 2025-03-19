using System.ComponentModel.DataAnnotations;

namespace Api.RequestDTOs;

public class CreateUserDTO
{
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string Password { get; set; }
    public string AvatarUrl { get; set; } = string.Empty;
    public DateOnly Birthday { get; set; }
    [Required]
    public int RoleId { get; set; }
    
}