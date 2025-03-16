namespace Core.ResponseDTOs;

public class PrizeResponseDTO
{
    public int Id { get; set; }
    public required string PrizeName { get; set; }
    public required string PrizeImage { get; set; }
    public int Points { get; set; }
}