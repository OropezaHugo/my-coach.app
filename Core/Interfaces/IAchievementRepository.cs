using Core.Entities;
using Core.Entities.GamificationEntities;
using Core.ResponseDTOs;

namespace Core.Interfaces;

public interface IAchievementRepository
{
    Task<IEnumerable<(UserAchievements, Achievement)>> GetAchievementsByUserId(int userId);
}