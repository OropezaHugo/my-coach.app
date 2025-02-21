namespace Core.Entities.ExerciseEntities;

public class Routine: BaseEntity
{
    public required string RoutineName { get; set; }
    public List<RoutineExercise> RoutineExercises { get; set; } = new List<RoutineExercise>();
    public List<UserRoutine> UserRoutines { get; set; } = new List<UserRoutine>();
}