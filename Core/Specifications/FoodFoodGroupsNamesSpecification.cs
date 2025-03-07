using Core.Entities.DietEntities;
using Core.ResponseDTOs;

namespace Core.Specifications;

public class FoodFoodGroupsNamesSpecification: BaseSpecification<Food, string>
{
    public FoodFoodGroupsNamesSpecification()
    {
        AddSelect(x => x.FoodGroup);
        ApplyDistinct();
    }
}