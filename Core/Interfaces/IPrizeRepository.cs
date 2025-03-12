using Core.Entities;

namespace Core.Interfaces;

public interface IPrizeRepository
{
    Task<IEnumerable<(UserPrize, Prize)>> GetPrizesByUserId(int userId);
}