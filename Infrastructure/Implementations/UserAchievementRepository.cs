using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

public class UserAchievementRepository(CoachAppContext context): IUserAchievementRepository
{
    public async Task<bool> ChangeAchievementBadgeState(int id, bool isBadge)
    {
        var userAchievement = await context.UserAchievements.FirstOrDefaultAsync(achievements => achievements.Id == id);
        if (userAchievement == null) return false;
        var userBadges = await context.UserAchievements.Where(achievements => achievements.UserId == userAchievement.UserId && achievements.IsBadge).ToListAsync();
        if (userBadges.Count > 2 && isBadge) return false;
        userAchievement.IsBadge = isBadge;
        context.Set<UserAchievements>().Attach(userAchievement);
        context.Entry(userAchievement).State = EntityState.Modified;
        return await context.SaveChangesAsync() > 0;
    }
}