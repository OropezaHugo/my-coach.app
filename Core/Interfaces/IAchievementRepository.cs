using Core.Entities;
using Core.Entities.GamificationEntities;
using Core.ResponseDTOs;

namespace Core.Interfaces;

public interface IAchievementRepository
{
    Task<IEnumerable<(UserAchievements, Achievement)>> GetAchievementsByUserId(int userId);
    Task<IEnumerable<(UserAchievements, Achievement)>> GetAchievementsBadgesByUserId(int userId);
    void AddOnePointProgressToExerciseAchievement(int userId, int exerciseId);
    void ReduceOnePointProgressToExerciseAchievement(int userId, int exerciseId);
}