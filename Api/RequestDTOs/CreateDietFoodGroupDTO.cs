namespace Api.RequestDTOs;

public class CreateDietFoodGroupDTO
{
    public int DietId { get; set; }
    public int FoodGroupId { get; set; }
    public TimeOnly FoodGroupTime { get; set; }
}