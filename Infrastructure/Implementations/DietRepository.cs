using Core.Entities;
using Core.Entities.DietEntities;
using Core.Interfaces;
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
}