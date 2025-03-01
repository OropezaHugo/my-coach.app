namespace Core.ResponseDTOs;

public class UserTrainingPlanInfoDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int TrainingPlanId { get; set; }
    public required string Objective { get; set; }
    public required DateOnly AssignedDate { get; set; }

}