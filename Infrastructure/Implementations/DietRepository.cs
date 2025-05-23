using Core.Entities;
using Core.Entities.DietEntities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

public class DietRepository(CoachAppContext context): IDietRepository
{
    public async Task<IEnumerable<(Diet, UserDiet)>> GetDietsByUserId(int id)
    {
        var res = await context.UserDiets.Where(userdiet => userdiet.UserId == id)
            .Join(context.Diets, userdiet => userdiet.DietId, diet => diet.Id, (userdiet, diet) => new {diet, userdiet}).ToListAsync();
        return res.Select(x => (x.diet, x.userdiet));

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
                                    FoodName = food.FoodName,
                                    FoodGroup = food.FoodGroup,
                                    FoodAshGr = food.FoodAshGr,
                                    FoodCalciumGr = food.FoodCalciumGr,
                                    FoodCarbsGr = food.FoodCarbsGr,
                                    FoodEnergyKcal = food.FoodEnergyKcal,
                                    FoodFatGr = food.FoodFatGr,
                                    FoodFibberGr = food.FoodFibberGr,
                                    FoodHumidityGr = food.FoodHumidityGr,
                                    FoodIronMg = food.FoodIronMg,
                                    FoodPhosphorusMg = food.FoodPhosphorusMg,
                                    FoodProteinGr = food.FoodProteinGr,
                                    FoodSubGroup = food.FoodSubGroup,
                                    FoodVitaminAMig = food.FoodVitaminAMig,
                                    FoodVitaminB1Mg = food.FoodVitaminB1Mg,
                                    FoodVitaminB2Mg = food.FoodVitaminB2Mg,
                                    FoodVitaminB3Mg = food.FoodVitaminB3Mg,
                                    FoodVitaminCMg = food.FoodVitaminCMg,
                                }).ToList()
                    }
                ).ToListAsync().Result
        };
        return res;
    }
}