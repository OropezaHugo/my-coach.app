namespace Api.RequestDTOs;

public class CreateTrainingRecordDTO
{
    public required double WeightLifted { get; set; }
    public required int RepetitionsMade { get; set; }
    public required DateOnly RecordDate { get; set; }
    public required int UserId { get; set; }
    public required int ExerciseId { get; set; }
}