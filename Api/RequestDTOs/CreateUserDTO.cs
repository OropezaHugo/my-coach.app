using System.ComponentModel.DataAnnotations;

namespace Api.RequestDTOs;

public class CreateUserDTO
{
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Email { get; set; }
    
    public string Endpoint { get; set; } = string.Empty;
    public string P256dh { get; set; }  = string.Empty;
    public string Auth { get; set; }  = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public DateOnly Birthday { get; set; }
    [Required]
    public int RoleId { get; set; }
    
}