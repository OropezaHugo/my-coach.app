namespace Core.ResponseDTOs;

public class TrainingPlanRoutineResponseDTO
{
    public required int Id { get; set; }
    public required int TrainingPlanId { get; set; }
    public required int RoutineId { get; set; }
    public required string RoutineWeekDay { get; set; }
    public required TimeOnly ArrivalTime { get; set; }
}