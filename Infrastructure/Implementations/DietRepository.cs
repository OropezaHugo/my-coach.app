using Core.Entities;
using Core.Entities.DietEntities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

public class DietRepository(CoachAppContext context): IDietRepository
{
    public async Task<List<(Diet, UserDiet)>> GetDietsByUserId(int id)
    {
        var res = await context.UserDiets.Where(userdiet => userdiet.UserId == id)
            .Join(context.Diets, userdiet => userdiet.DietId, diet => diet.Id, (userdiet, diet) => new {diet, userdiet}).ToListAsync();
        return res.Select(x => (x.diet, x.userdiet)).ToList();

    }
    public async Task<DietContentResponseDTO?> GetDietContentByDietId(int dietId)
    {
        var diet = await context.Diets.FirstOrDefaultAsync(diet => diet.Id == dietId);
        if (diet == null) return null;
        DietContentResponseDTO res = new DietContentResponseDTO()
        {
            DietId = diet.Id,
            DietName = diet.DietName,
            WaterAmount = diet.WaterAmount,
            DietFoodGroupInfos = context.DietFoodGroups.Where(dietGroup => dietGroup.DietId == dietId)
                .Join(context.FoodGroups, dietgroup => dietgroup.FoodGroupId, group => group.Id, (dietgroup, group) =>
                    new DietFoodGroupContentDTO()
                    {
                        DietId = dietgroup.DietId,
                        FoodGroupId = group.Id,
                        FoodGroupName = group.FoodGroupName,
                        FoodGroupTime = dietgroup.FoodGroupTime,
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
                ).ToListAsync().Result
        };
        return res;
    }
}