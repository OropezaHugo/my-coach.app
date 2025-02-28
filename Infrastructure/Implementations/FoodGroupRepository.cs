using Core.Interfaces;
using Core.ResponseDTOs;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

public class FoodGroupRepository(CoachAppContext context): IFoodGroupRepository
{
    public async Task<List<DietFoodGroupContentDTO>> GetDietContentByDietId(int dietId)
    {
        List<DietFoodGroupContentDTO> res = context.DietFoodGroups.Where(dietGroup => dietGroup.DietId == dietId)
            .Join(context.FoodGroups, dietgroup => dietgroup.FoodGroupId, group => group.Id, (dietgroup, group) =>
                new DietFoodGroupContentDTO()
                {
                    DietId = dietgroup.DietId,
                    FoodGroupId = group.Id,
                    FoodGroupName = group.FoodGroupName,
                    Id = dietgroup.Id,
                    FoodGroupFoodInfos = context.FoodGroupFoods
                        .Where(foodGroupFood => foodGroupFood.FoodGroupId == group.Id)
                        .Join(context.Foods, foodgroup => foodgroup.FoodId, food => food.Id, (foodgroup, food) =>
                            new FoodGroupFoodContentDTO()
                            {
                                Id = foodgroup.Id,
                                FoodId = food.Id,
                                FoodAmount = foodgroup.FoodAmount,
                                FoodGroupId = foodgroup.FoodGroupId,
                                FoodName = food.FoodName
                            }).ToList()
                }
            ).ToListAsync().Result;
        return res;
    }
}