namespace Core.ResponseDTOs;

public class DietFoodGroupResponseDTO
{
    public int Id { get; set; }
    public int DietId { get; set; }
    public int FoodGroupId { get; set; }
    public TimeOnly FoodGroupTime { get; set; }
}