namespace Core.ResponseDTOs;

public class UserDietInfoDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int DietId { get; set; }
    public DateOnly AssignedDate { get; set; }
    public required string DietName { get; set; }
    public double WaterAmount { get; set; }
}