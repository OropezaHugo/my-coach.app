namespace Core.ResponseDTOs;

public class UserDietResponseDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int DietId { get; set; }
    public DateOnly AssignedDate { get; set; }
}