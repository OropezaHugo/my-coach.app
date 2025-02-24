namespace Api.RequestDTOs;

public class CreateFoodGroupDTO
{
    public required int Id { get; set; }
    public required string FoodGroupName { get; set; }
}