using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.DietEntities;

public class FoodGroupFood: BaseEntity
{
    public int FoodGroupId { get; set; }
    [ForeignKey(nameof(FoodGroupId))]
    public FoodGroup? FoodGroup { get; set; }
    
    public int FoodId { get; set; }
    [ForeignKey(nameof(FoodId))]
    public Food? Food { get; set; }
    
    public double FoodAmount { get; set; }
}