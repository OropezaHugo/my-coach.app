using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.DietEntities;

public class DietFoodGroup: BaseEntity
{
    public int DietId { get; set; }
    [ForeignKey(nameof(DietId))]
    public Diet? Diet { get; set; }
    
    public int FoodGroupId { get; set; }
    [ForeignKey(nameof(FoodGroupId))]
    public FoodGroup? FoodGroup { get; set; }
    
    public TimeOnly FoodGroupTime { get; set; }
}