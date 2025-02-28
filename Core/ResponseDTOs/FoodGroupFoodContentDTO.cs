namespace Core.ResponseDTOs;

public class FoodGroupFoodContentDTO
{
    public required int Id { get; set; }
    public required int FoodGroupId { get; set; }
    public required int FoodId { get; set; }
    public required double FoodAmount { get; set; }
    public required string FoodName { get; set; }

}