using Core.Entities.TrainingPlanEntities;

namespace Core.Interfaces;

public interface ISetRepository
{
    Task<List<Set>> GetSetsByExerciseId(int id);
}