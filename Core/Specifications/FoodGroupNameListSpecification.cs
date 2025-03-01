using Core.Entities.DietEntities;

namespace Core.Specifications;

public class FoodGroupNameListSpecification: BaseSpecification<FoodGroup, string>
{
    public FoodGroupNameListSpecification()
    {
        AddSelect(x => x.FoodGroupName);
        ApplyDistinct();
    }
}