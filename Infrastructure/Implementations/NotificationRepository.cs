using Core.Entities;
using Core.Entities.DietEntities;
using Core.Entities.GamificationEntities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

public class NotificationRepository(CoachAppContext context): INotificationRepository
{
    public async Task<IEnumerable<NotificationSubscription>> CheckForFoodRemindersAsync()
    {
        var mostRecentDietsChecked = context.UserDiets
            .OrderByDescending(userDiet => userDiet.AssignedDate)
            .AsEnumerable()
            .DistinctBy(userDiet => userDiet.UserId)
            .Where(userDiet => ExistAnyFoodGroupToRemind(userDiet))
            .ToList();
        var result = mostRecentDietsChecked.Join(context.NotificationSubscriptions, userDiet => userDiet.UserId,
            subscription => subscription.UserId,
            (userDiet, subscription) => subscription).ToList();
        return result;
    }
    
    
    public async Task<IEnumerable<NotificationSubscription>> CheckForTrainingRemindersAsync()
    {
        var mostRecentUserTrainingPlansChecked = context.UserTrainingPlans
            .OrderByDescending(userTrainingPlans => userTrainingPlans.AssignedDate)
            .AsEnumerable()
            .DistinctBy(userTrainingPlan => userTrainingPlan.UserId)
            .Where(plans => ExistAnyRoutineToRemind(plans))
            .ToList();
        var result = mostRecentUserTrainingPlansChecked.Join(context.NotificationSubscriptions, plans => plans.UserId,
            subscription => subscription.UserId,
            (plans, subscription) => subscription).ToList();
        return result;
    }

    private bool ExistAnyRoutineToRemind(UserTrainingPlans? trainingPlan)
    {
        if (trainingPlan == null) return false;
        var routines = context.TrainingPlanRoutines.Where(trainingPlanRoutines =>
            trainingPlan.TrainingPlanId == trainingPlanRoutines.TrainingPlanId).ToList();
        return routines
            .Any(trainingPlanRoutines => 
                DateTime.Now.DayOfWeek == GetDayOfWeek(trainingPlanRoutines.RoutineWeekDay)
                && TimeOnly.FromDateTime(DateTime.Now).Hour == trainingPlanRoutines.ArrivalTime.AddMinutes(-15).Hour
                && TimeOnly.FromDateTime(DateTime.Now).Minute == trainingPlanRoutines.ArrivalTime.AddMinutes(-15).Minute);
    }
    
    private bool ExistAnyFoodGroupToRemind(UserDiet? diet)
    {
        if (diet == null) return false;
        var dietFoodGroups = context.DietFoodGroups.Where(dietFoodGroup =>
            diet.DietId == dietFoodGroup.DietId).ToList();
        return dietFoodGroups
            .Any(dietFoodGroup => 
                TimeOnly.FromDateTime(DateTime.Now).Hour == dietFoodGroup.FoodGroupTime.Hour
                && TimeOnly.FromDateTime(DateTime.Now).Minute == dietFoodGroup.FoodGroupTime.Minute);
    }

    private DayOfWeek? GetDayOfWeek(string dayOfWeek)
    {
        switch (dayOfWeek.ToLower())
        {
            case "monday":
                return DayOfWeek.Monday;
            case "tuesday":
                return DayOfWeek.Tuesday;
            case "wednesday":
                return DayOfWeek.Wednesday;
            case "thursday":
                return DayOfWeek.Thursday;
            case "friday":
                return DayOfWeek.Friday;
            case "saturday":
                return DayOfWeek.Saturday;
            case "sunday":
                return DayOfWeek.Sunday;
            default:
                return null;
        }
    }
}