using Core.Entities;
using Core.Entities.TrainingPlanEntities;
using Core.ResponseDTOs;

namespace Core.Interfaces;

public interface ITrainingPlanRepository
{
    Task<List<(TrainingPlan, UserTrainingPlans)>> GetTrainingPlansByUserId(int id);
    Task<TrainingPlanContentResponseDTO?> GetTrainingPlanContentByTrainingPlanId(int id);
    
}