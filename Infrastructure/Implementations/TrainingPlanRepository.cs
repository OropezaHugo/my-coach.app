using Core.Entities;
using Core.Entities.TrainingPlanEntities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

public class TrainingPlanRepository(CoachAppContext context): ITrainingPlanRepository
{
    public async Task<List<(TrainingPlan, UserTrainingPlans)>> GetRoutinesByUserId(int id)
    {
        var res = await context.UserTrainingPlans.Where(userTrainingPlans => userTrainingPlans.UserId == id)
            .Join(context.TrainingPlans, userTrainingPlans => userTrainingPlans.TrainingPlanId, trainingPlan => trainingPlan.Id, (userTrainingPlans, trainingPlan) => new {trainingPlan, userTrainingPlans}).ToListAsync();
        return res.Select(x => (x.trainingPlan, x.userTrainingPlans)).ToList();
    }
}