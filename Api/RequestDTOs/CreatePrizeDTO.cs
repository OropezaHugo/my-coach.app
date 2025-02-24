namespace Api.RequestDTOs;

public class CreatePrizeDTO
{
    public required string PrizeName { get; set; }
    public int Points { get; set; }   
}