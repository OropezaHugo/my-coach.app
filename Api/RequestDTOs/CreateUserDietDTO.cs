namespace Api.RequestDTOs;

public class CreateUserDietDTO
{
    public int UserId { get; set; }
    public int DietId { get; set; }
    public DateOnly AssignedDate { get; set; }
}