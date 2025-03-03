using Core.Entities.TrainingPlanEntities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

public class SetRepository(CoachAppContext context): ISetRepository
{
    public async Task<List<Set>> GetSetsByExerciseId(int id)
    {
        return await context.ExerciseSets.Where(ex => ex.ExerciseId == id)
            .Join(context.Sets, ex => ex.SetId, set => set.Id, (ex, set) => set).ToListAsync();
    }
}