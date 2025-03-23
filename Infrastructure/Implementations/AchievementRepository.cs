using Core.Entities;
using Core.Entities.GamificationEntities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

public class AchievementRepository(CoachAppContext context): IAchievementRepository
{
    public async Task<IEnumerable<(UserAchievements, Achievement)>> GetAchievementsByUserId(int userId)
    {
        var res = await context.UserAchievements.Where(userAchievement => userAchievement.UserId == userId)
            .Join(context.Achievements, ua => ua.AchievementId, a => a.Id, (ua, achievement) => new {ua, achievement}).ToListAsync();
        return res.Select(x => (x.ua, x.achievement));
    }
}