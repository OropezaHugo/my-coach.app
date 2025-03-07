using Core.Entities.DietEntities;

namespace Core.Specifications;

public class FoodSubGroupNamesSpecification: BaseSpecification<Food, string>
{
    public FoodSubGroupNamesSpecification()
    {
        AddSelect(x => x.FoodSubGroup);
        ApplyDistinct();
    }
}