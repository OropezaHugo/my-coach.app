namespace Api.RequestDTOs;

public class CreateUserRoutineDTO
{
    public int UserId { get; set; }
    public int RoutineId { get; set; }
    public DateOnly TargetDate { get; set; }
}