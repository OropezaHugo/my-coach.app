using Core.Entities;
using Core.Entities.TrainingPlanEntities;

namespace Core.Interfaces;

public interface ITrainingPlanRepository
{
    Task<List<(TrainingPlan, UserTrainingPlans)>> GetRoutinesByUserId(int id);
}