namespace Core.ResponseDTOs;

public class UserRoutineInfoDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoutineId { get; set; }
    public DateOnly TargetDate { get; set; }
    public required string RoutineName { get; set; }
}