namespace Core.ResponseDTOs;

public class UserPrizeInfoDTO
{
    
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PrizeId { get; set; }
    public required string PrizeName { get; set; }
    public int Points { get; set; }
}