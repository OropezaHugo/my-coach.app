namespace Api.RequestDTOs;

public class CreateDietDTO
{
    public required string DietName { get; set; }
    public double WaterAmount { get; set; }
}