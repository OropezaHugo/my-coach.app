namespace Core.ResponseDTOs;

public class UserPrizeResponseDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PrizeId { get; set; }
    public DateOnly ObtainedDate { get; set; }
}