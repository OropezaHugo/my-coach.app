using Core.Entities.DietEntities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Implementations;

public class FoodRepository(CoachAppContext context) : IFoodRepository
{
    public async Task<List<FoodFoodGroupsAndFoodSubGroupsFilterDTO>> GetFoodGroupsAndFoodSubGroups()
    {
        var result = new List<FoodFoodGroupsAndFoodSubGroupsFilterDTO>();
        foreach (Food food in context.Foods)
        {
            if (result.Any(dto => dto.FoodGroup == food.FoodGroup))
            {
                if (result.First(dto => dto.FoodGroup == food.FoodGroup).FoodSubGroups.All(s => s != food.FoodSubGroup))
                {
                    result.First(dto => dto.FoodGroup == food.FoodGroup).FoodSubGroups.Add(food.FoodSubGroup);
                }
            }
            else
            {
                result.Add(new FoodFoodGroupsAndFoodSubGroupsFilterDTO()
                {
                    FoodGroup = food.FoodGroup,
                    FoodSubGroups = new List<string>()
                    {
                        food.FoodSubGroup
                    }
                });
            }
        }
        return result;
    }
}