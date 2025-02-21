namespace Core.Entities.ExerciseEntities;

public class Exercise: BaseEntity
{
    public required string ExerciseName { get; set; }
    public List<ExerciseSet> ExerciseSets { get; set; } = new List<ExerciseSet>();
    public List<RoutineExercise> RoutineExercises { get; set; } = new List<RoutineExercise>();
}