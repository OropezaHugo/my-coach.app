using Core.Entities.DietEntities;

namespace Core.Specifications;

public class DietNameListSpecification: BaseSpecification<Diet, string>
{
    public DietNameListSpecification()
    {
        AddSelect(x => x.DietName);
        ApplyDistinct();
    }
}