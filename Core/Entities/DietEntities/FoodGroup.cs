namespace Core.Entities.DietEntities;

public class FoodGroup: BaseEntity
{
    public required string FoodGroupName { get; set; }
    public List<FoodGroupFood> FoodGroupFoods { get; set; } = new List<FoodGroupFood>();
    public List<DietFoodGroup> DietFoodGroups { get; set; } = new List<DietFoodGroup>();
}