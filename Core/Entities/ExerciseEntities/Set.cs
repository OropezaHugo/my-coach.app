namespace Core.Entities.ExerciseEntities;

public class Set: BaseEntity
{
    public int Repetitions { get; set; }
    public double Weight { get; set; }
    public List<ExerciseSet> ExerciseSets { get; set; } = new List<ExerciseSet>();
}