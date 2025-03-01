namespace Core.ResponseDTOs;

public class TrainingPlanContentResponseDTO
{
    
    public required int TrainingPlanId { get; set; }
    public required string Objective { get; set; }
    public required List<TrainingPlanRoutineContentDTO> RoutineResponses { get; set; }
}