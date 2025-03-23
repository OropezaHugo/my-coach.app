using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

public class AuthRepository(CoachAppContext context): IAuthRepository
{
    public async Task<User?> GetUserByEmailWithRole(string email)
    {
        return await context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> RegisterUser(User user)
    {
        var newUser = context.Set<User>().Add(user).Entity;
        await context.SaveChangesAsync();
        await context.Achievements.ForEachAsync(achievement =>
        {
            context.UserAchievements.Add(new UserAchievements()
            {
                AchievementId = achievement.Id,
                UserId = newUser.Id,
                AchievementActualLevel = 0,
                AchievementStepsProgress = 0
            });
            context.SaveChanges();
        });
        
        return newUser;
    }
}