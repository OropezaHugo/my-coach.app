using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.ExerciseEntities;

public class RoutineExercise: BaseEntity
{
    public int RoutineId { get; set; }
    [ForeignKey(nameof(RoutineId))]
    public Routine? Routine { get; set; }
    
    public int ExerciseId { get; set; }
    [ForeignKey(nameof(ExerciseId))]
    public Exercise? Exercise { get; set; }
    
    public int Effort { get; set; }
}