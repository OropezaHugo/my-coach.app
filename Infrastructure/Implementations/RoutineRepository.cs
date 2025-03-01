using Core.Entities;
using Core.Entities.ExerciseEntities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

public class RoutineRepository(CoachAppContext context): IRoutineRepository
{
    public async Task<List<(Routine, UserRoutine)>> GetRoutinesByUserId(int id)
    {
        var res = await context.UserRoutines.Where(userRoutine => userRoutine.UserId == id)
            .Join(context.Routines, userRoutine => userRoutine.RoutineId, routine => routine.Id, (userRoutine, routine) => new {routine, userRoutine}).ToListAsync();
        return res.Select(x => (x.routine, x.userRoutine)).ToList();
    }
}