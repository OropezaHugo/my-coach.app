using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.TrainingPlanEntities;

public class TrainingPlanRoutines: BaseEntity
{
    public required int TrainingPlanId { get; set; }
    [ForeignKey(nameof(TrainingPlanId))]
    public TrainingPlan? TrainingPlan { get; set; }
    
    public required int RoutineId { get; set; }
    [ForeignKey(nameof(RoutineId))]
    public Routine? Routine { get; set; }
    
    public required string RoutineWeekDay { get; set; }
}