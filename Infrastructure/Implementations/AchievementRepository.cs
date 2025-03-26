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

    public void AddOnePointProgressToExerciseAchievement(int userId, int exerciseId)
    {
        var achievement = context.Achievements.FirstOrDefault(achievement => achievement.ExerciseId == exerciseId);
        if (achievement == null) return;
        var userAchievement = context.UserAchievements.FirstOrDefault(achievements =>
            achievements.AchievementId == achievement.Id && achievements.UserId == userId);
        if (userAchievement == null) return;
        if (userAchievement.AchievementActualLevel < achievement.AchievementStepsPerLevel.Count && userAchievement.AchievementStepsProgress + 1 >= achievement.AchievementStepsPerLevel[userAchievement.AchievementActualLevel])
        {
            userAchievement.AchievementActualLevel += 1;
            userAchievement.AchievementStepsProgress = 0;
        }
        else
        {
            userAchievement.AchievementStepsProgress += 1;
        }
        context.UserAchievements.Update(userAchievement);
        context.SaveChanges();
    }

    public void ReduceOnePointProgressToExerciseAchievement(int userId, int exerciseId)
    {
        
        var achievement = context.Achievements.First(achievement => achievement.ExerciseId == exerciseId);
        var userAchievement = context.UserAchievements.First(achievements =>
            achievements.AchievementId == achievement.Id && achievements.UserId == userId);
        
        if (userAchievement.AchievementActualLevel < achievement.AchievementStepsPerLevel.Count && userAchievement.AchievementStepsProgress - 1 < 0)
        {
            userAchievement.AchievementActualLevel -= 1;
            userAchievement.AchievementStepsProgress = achievement.AchievementStepsPerLevel[userAchievement.AchievementActualLevel] - 1;
        }
        else
        {
            userAchievement.AchievementStepsProgress -= 1;
        }
        context.UserAchievements.Update(userAchievement);
        context.SaveChanges();
    }
}