namespace Api.RequestDTOs;

public class CreateUserPrizeDTO
{
    public int UserId { get; set; }
    public int PrizeId { get; set; }
    public DateOnly ObtainedDate { get; set; }
}