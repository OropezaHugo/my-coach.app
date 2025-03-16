namespace Core.Entities;

public class Prize: BaseEntity
{
    public required string PrizeName { get; set; }
    public required string PrizeImage { get; set; }
    public int Points { get; set; }
    public List<UserPrize> UserPrizes { get; set; } = new List<UserPrize>();
}