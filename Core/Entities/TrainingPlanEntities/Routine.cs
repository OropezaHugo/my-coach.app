namespace Core.Entities.TrainingPlanEntities;

public class Routine: BaseEntity
{
    public required string RoutineName { get; set; }
    public List<RoutineExercise> RoutineExercises { get; set; } = new List<RoutineExercise>();
    public List<TrainingPlanRoutines> TrainingPlanRoutines { get; set; } = new List<TrainingPlanRoutines>();
}