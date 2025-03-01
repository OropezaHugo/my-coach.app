using Core.Entities;
using Core.Entities.ExerciseEntities;

namespace Core.Interfaces;

public interface IRoutineRepository
{
    Task<List<(Routine, UserRoutine)>> GetRoutinesByUserId(int id);
}