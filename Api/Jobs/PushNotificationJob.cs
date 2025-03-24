using System.Text.Json;
using System.Text.Json.Nodes;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Quartz;
using WebPush;

namespace Api.Jobs;

public class PushNotificationJob(
    IGenericRepository<User> userRepository,
    IConfiguration configuration
    ): IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        var users = await userRepository.ListAllAsync();
        var vapidDetails = new VapidDetails()
        {
            Subject = configuration["Vapid:Subject"],
            PrivateKey = configuration["Vapid:PrivateKey"],
            PublicKey = configuration["Vapid:PublicKey"],
        };
        var webPushClient = new WebPushClient();
        foreach (User user in users)
        {
            if (user.Endpoint.Length > 10)
            {
                var pushSubscription = new PushSubscription(user.Endpoint, user.P256dh, user.Auth);
                string payload = "{   \"notification\": {     \"title\": \"New Notification!\",     \"data\": {       \"onActionClick\": {         \"default\": {\"operation\": \"openWindow\", \"url\": \"foo\"}       }     }   } }";

                await webPushClient.SendNotificationAsync(pushSubscription, payload, vapidDetails);    
            }
            
        }
    }
}