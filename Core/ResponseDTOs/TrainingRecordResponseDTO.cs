namespace Core.ResponseDTOs;

public class TrainingRecordResponseDTO
{
    public required int Id { get; set; }
    public required double WeightLifted { get; set; }
    public required int RepetitionsMade { get; set; }
    public required DateOnly RecordDate { get; set; }
    public required int UserId { get; set; }
    public required int ExerciseId { get; set; }
}