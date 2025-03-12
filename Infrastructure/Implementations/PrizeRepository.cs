using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

public class PrizeRepository(CoachAppContext context): IPrizeRepository
{
    public async Task<IEnumerable<(UserPrize, Prize)>> GetPrizesByUserId(int userId)
    {
        var result = await context.UserPrizes.Where(p => p.UserId == userId)
            .Join(context.Prizes, userPrize => userPrize.PrizeId, prize => prize.Id, (userPrize, prize) => new {userPrize, prize} ).ToListAsync();
        return result.Select(x => (x.userPrize, x.prize));
    }
}