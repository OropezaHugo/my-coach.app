using Core.Entities;
using Core.Entities.TrainingPlanEntities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

public class TrainingPlanRepository(CoachAppContext context): ITrainingPlanRepository
{
    public async Task<List<(TrainingPlan, UserTrainingPlans)>> GetTrainingPlansByUserId(int id)
    {
        var res = await context.UserTrainingPlans.Where(userTrainingPlans => userTrainingPlans.UserId == id)
            .Join(context.TrainingPlans, userTrainingPlans => userTrainingPlans.TrainingPlanId, trainingPlan => trainingPlan.Id, (userTrainingPlans, trainingPlan) => new {trainingPlan, userTrainingPlans}).ToListAsync();
        return res.Select(x => (x.trainingPlan, x.userTrainingPlans)).ToList();
    }

    public async Task<TrainingPlanContentResponseDTO?> GetTrainingPlanContentByTrainingPlanId(int id)
    {
        var trainingPlan = await context.TrainingPlans.FirstOrDefaultAsync(trainingPlan => trainingPlan.Id == id);
        if (trainingPlan == null) return null;
        TrainingPlanContentResponseDTO res = new TrainingPlanContentResponseDTO()
        {
            Objective = trainingPlan.Objective,
            TrainingPlanId = trainingPlan.Id,
            RoutineResponses = context.TrainingPlanRoutines.Where(plan => plan.TrainingPlanId == id)
                .Join(context.Routines, plan => plan.RoutineId, routine => routine.Id,
                    (plan, routine) => new TrainingPlanRoutineContentDTO()
                    {
                        RoutineId = routine.Id,
                        TrainingPlanId = plan.TrainingPlanId,
                        Id = plan.Id,
                        RoutineName = routine.RoutineName,
                        RoutineWeekDay = plan.RoutineWeekDay,
                        RoutineExerciseContent = context.RoutineExercises.Where(routineExercise => routineExercise.RoutineId == routine.Id)
                            .Join(context.Exercises, routineExercise => routineExercise.ExerciseId, exercise => exercise.Id, 
                                (routineExercise, exercise) => new RoutineExerciseContentDTO()
                            {
                                ExerciseId = exercise.Id,
                                ExerciseName = exercise.ExerciseName,
                                RoutineId = routineExercise.RoutineId,
                                Id = routineExercise.Id,
                                Effort = routineExercise.Effort,
                                ExerciseSetContent = context.ExerciseSets.Where(set => set.ExerciseId == exercise.Id)
                                    .Join(context.Sets, exerciseSet => exerciseSet.SetId, set => set.Id, (exerciseSet, set) => new ExerciseSetContentDTO()
                                    {
                                        ExerciseId = exerciseSet.ExerciseId,
                                        SetId = set.Id,
                                        Fatigue = exerciseSet.Fatigue,
                                        Id = exerciseSet.Id,
                                        Repetitions = set.Repetitions,
                                        Weight = set.Weight,
                                    }).ToList()
                            }).ToList()
                    }).ToList()
        };
        return res;
    }
}