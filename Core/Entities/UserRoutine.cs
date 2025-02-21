using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.ExerciseEntities;

namespace Core.Entities;

public class UserRoutine: BaseEntity
{
    
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
    
    public int RoutineId { get; set; }
    [ForeignKey(nameof(RoutineId))]
    public Routine? Routine { get; set; }
    
    public DateOnly TargetDate { get; set; }
}