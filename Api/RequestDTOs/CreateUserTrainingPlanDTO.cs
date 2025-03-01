namespace Api.RequestDTOs;

public class CreateUserTrainingPlanDTO
{
    public required int UserId { get; set; }
    public required int TrainingPlanId { get; set; }
    public required DateOnly AssignedDate { get; set; }
}