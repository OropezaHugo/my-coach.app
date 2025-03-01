namespace Core.ResponseDTOs;

public class DietFoodGroupContentDTO
{
    public required int Id { get; set; }
    public required int FoodGroupId { get; set; }
    public required int DietId { get; set; }
    public required string FoodGroupName { get; set; }
    public required TimeOnly FoodGroupTime { get; set; }
    public List<FoodGroupFoodContentDTO> FoodGroupFoodInfos { get; set; } = new List<FoodGroupFoodContentDTO>();
}