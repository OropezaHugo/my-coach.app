namespace Core.ResponseDTOs;

public class TrainingPlanRoutineContentDTO
{
    public required int Id { get; set; }
    public required int TrainingPlanId { get; set; }
    public required int RoutineId { get; set; }
    public required string RoutineName { get; set; }
    public required string RoutineWeekDay { get; set; }
    public required TimeOnly ArrivalTime { get; set; }
    public required List<RoutineExerciseContentDTO> RoutineExerciseContent { get; set; }
}