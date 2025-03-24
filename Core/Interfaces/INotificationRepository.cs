using Core.Entities.GamificationEntities;

namespace Core.Interfaces;

public interface INotificationRepository
{
    Task<IEnumerable<NotificationSubscription>> CheckForFoodRemindersAsync();
    Task<IEnumerable<NotificationSubscription>> CheckForTrainingRemindersAsync();
}