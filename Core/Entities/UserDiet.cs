using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.DietEntities;

namespace Core.Entities;

public class UserDiet: BaseEntity
{
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
    
    public int DietId { get; set; }
    [ForeignKey(nameof(DietId))]
    public Diet? Diet { get; set; }
    
    public DateOnly AssignedDate { get; set; }
}