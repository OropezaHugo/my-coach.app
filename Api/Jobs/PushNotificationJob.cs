using System.Text.Json;
using System.Text.Json.Nodes;
using Core.Entities;
using Core.Entities.GamificationEntities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Quartz;
using WebPush;

namespace Api.Jobs;

public class PushNotificationJob(
    INotificationRepository notificationRepository,
    IConfiguration configuration
    ): IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        var trainingReminderSubscriptions = await notificationRepository.CheckForTrainingRemindersAsync();
        var eatingReminderSubscriptions = await notificationRepository.CheckForFoodRemindersAsync();
        var vapidDetails = new VapidDetails()
        {
            Subject = configuration["Vapid:Subject"],
            PrivateKey = configuration["Vapid:PrivateKey"],
            PublicKey = configuration["Vapid:PublicKey"],
        };
        var webPushClient = new WebPushClient();
        foreach (NotificationSubscription subscription in trainingReminderSubscriptions.AsEnumerable())
        {
            if (subscription.Endpoint.Length > 10)
            {
                var pushSubscription = new PushSubscription(subscription.Endpoint, subscription.P256dh, subscription.Auth);
                string payload = "{   \"notification\": {     \"title\": \"Es hora de entrenar\",     \"data\": {       \"onActionClick\": {         \"default\": {\"operation\": \"openWindow\", \"url\": \"foo\"}       }     }   } }";

                await webPushClient.SendNotificationAsync(pushSubscription, payload, vapidDetails);    
            }
            
        }
        foreach (NotificationSubscription subscription in eatingReminderSubscriptions.AsEnumerable())
        {
            if (subscription.Endpoint.Length > 10)
            {
                var pushSubscription = new PushSubscription(subscription.Endpoint, subscription.P256dh, subscription.Auth);
                string payload = "{   \"notification\": {     \"title\": \"Es hora de comer\",     \"data\": {       \"onActionClick\": {         \"default\": {\"operation\": \"openWindow\", \"url\": \"foo\"}       }     }   } }";

                await webPushClient.SendNotificationAsync(pushSubscription, payload, vapidDetails);    
            }
            
        }
    }
}