namespace Core.ResponseDTOs;

public class ExerciseSetContentDTO
{
    public int Id { get; set; }
    public int ExerciseId { get; set; }
    public int SetId { get; set; }
    public int Fatigue { get; set; }
    public int Repetitions { get; set; }
    public double Weight { get; set; }
}