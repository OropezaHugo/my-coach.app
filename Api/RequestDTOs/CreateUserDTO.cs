using System.ComponentModel.DataAnnotations;

namespace Api.RequestDTOs;

public class CreateUserDTO
{
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Email { get; set; }
    
    public DateOnly Birthday { get; set; }
    [Required]
    public int RoleId { get; set; }
    [Required]
    public int AvatarId { get; set; }
}