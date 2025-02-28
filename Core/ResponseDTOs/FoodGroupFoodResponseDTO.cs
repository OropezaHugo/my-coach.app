namespace Core.ResponseDTOs;

public class FoodGroupFoodResponseDTO
{
    public int Id { get; set; }
    public int FoodGroupId { get; set; }
    public int FoodId { get; set; }
    public double FoodAmount { get; set; }
}