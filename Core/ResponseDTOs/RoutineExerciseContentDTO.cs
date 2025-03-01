namespace Core.ResponseDTOs;

public class RoutineExerciseContentDTO
{
    public int Id { get; set; }
    public int RoutineId { get; set; }
    public int ExerciseId { get; set; }
    public int Effort { get; set; }
    public required string ExerciseName { get; set; }
    public List<ExerciseSetContentDTO> ExerciseSetContent { get; set; }
    
}