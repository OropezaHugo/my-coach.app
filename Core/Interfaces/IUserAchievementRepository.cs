namespace Core.Interfaces;

public interface IUserAchievementRepository
{
    public Task<bool> ChangeAchievementBadgeState(int id, bool isBadge);
}