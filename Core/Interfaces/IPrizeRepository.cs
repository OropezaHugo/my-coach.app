using Core.Entities;
using Core.Entities.GamificationEntities;

namespace Core.Interfaces;

public interface IPrizeRepository
{
    Task<IEnumerable<(UserPrize, Prize)>> GetPrizesByUserId(int userId);
}