namespace Api.RequestDTOs;

public class CreateTrainingPlanRoutineDTO
{
    public required int TrainingPlanId { get; set; }
    public required int RoutineId { get; set; }
    public required string RoutineWeekDay { get; set; }
}