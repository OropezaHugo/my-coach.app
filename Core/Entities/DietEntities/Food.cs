namespace Core.Entities.DietEntities;

public class Food: BaseEntity
{
    public required string FoodName { get; set; }
    public List<FoodGroupFood> FoodGroupFoods { get; set; } = new List<FoodGroupFood>();
}