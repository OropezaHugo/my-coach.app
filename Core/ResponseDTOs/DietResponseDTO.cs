namespace Core.ResponseDTOs;

public class DietResponseDTO
{
    public required int Id { get; set; }
    public required string DietName { get; set; }
    public double WaterAmount { get; set; }
}