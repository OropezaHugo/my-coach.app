namespace Core.ResponseDTOs;

public class UserTrainingPlanResponseDTO
{
    public required int Id { get; set; }
    public required int UserId { get; set; }
    public required int TrainingPlanId { get; set; }
    public required DateOnly AssignedDate { get; set; }
}