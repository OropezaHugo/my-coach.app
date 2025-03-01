using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.TrainingPlanEntities;

public class ExerciseSet: BaseEntity
{
    public int ExerciseId { get; set; }
    [ForeignKey(nameof(ExerciseId))]
    public Exercise? Exercise { get; set; }
    
    public int SetId { get; set; }
    [ForeignKey(nameof(SetId))]
    public Set? Set { get; set; }
    
    public int Fatigue { get; set; }
}