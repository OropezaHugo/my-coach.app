using Core.ResponseDTOs;

namespace Core.Interfaces;

public interface IFoodGroupRepository
{
    Task<List<DietFoodGroupContentDTO>> GetDietContentByDietId(int dietId);
}