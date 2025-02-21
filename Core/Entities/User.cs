using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class User: BaseEntity
{
    public required string Name { get; set; }
    public  required string Email { get; set; }
    public required string Password { get; set; }
    public string AvatarUrl { get; set; } = string.Empty;
    public DateOnly Birthday { get; set; }
    
    public int RoleId { get; set; }
    [ForeignKey(nameof(RoleId))]
    public Role? Role { get; set; }
    
    public List<UserRoutine> UserRoutines { get; set; } = new List<UserRoutine>();
    public List<UserDiet> UserDiets { get; set; } = new List<UserDiet>();
    public List<UserPrize> UserPrizes { get; set; } = new List<UserPrize>();
}