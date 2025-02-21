namespace Core.Entities.DietEntities;

public class Diet: BaseEntity
{
    public required string DietName { get; set; }
    public double WaterAmount { get; set; }
    public List<DietFoodGroup> DietFoodGroups { get; set; } = new List<DietFoodGroup>();
    public List<UserDiet> UserDiets { get; set; } = new List<UserDiet>();
}