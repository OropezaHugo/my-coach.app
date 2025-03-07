using Core.ResponseDTOs;

namespace Core.Interfaces;

public interface IFoodRepository
{
    Task<List<FoodFoodGroupsAndFoodSubGroupsFilterDTO>>  GetFoodGroupsAndFoodSubGroups();
}