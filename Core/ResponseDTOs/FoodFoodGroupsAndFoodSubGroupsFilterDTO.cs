namespace Core.ResponseDTOs;

public class FoodFoodGroupsAndFoodSubGroupsFilterDTO
{
    public required string FoodGroup { get; set; }
    public required List<string> FoodSubGroups { get; set; }
}