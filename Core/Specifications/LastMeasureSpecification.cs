using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications;

public class LastMeasureSpecification: BaseSpecification<ISAKMeasures>
{
    public LastMeasureSpecification(int userId): base(
        measures => measures.MeasureDate >= DateOnly.FromDateTime(DateTime.UtcNow.AddMonths(-3))
        && measures.UserId == userId
        )
    {
        AddOrderByDescending(measures => measures.MeasureDate);
    }
}