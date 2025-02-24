namespace Api.RequestDTOs;

public class CreateFoodGroupFoodDTO
{
    public int FoodGroupId { get; set; }
    public int FoodId { get; set; }
    public double FoodAmount { get; set; }
}