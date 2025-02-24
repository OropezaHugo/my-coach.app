namespace Api.ResponseDTOs;

public class UserRoutineResponseDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoutineId { get; set; }
    public DateOnly TargetDate { get; set; }
}