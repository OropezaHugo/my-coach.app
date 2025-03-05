using Core.Interfaces;
using Core.ResponseDTOs;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Implementations;

public class TrainingRecordRepository(CoachAppContext context): ITrainingRecordRepository
{
    public Task<List<ExerciseBasicDataDTO>> GetRecordExercisesByUserId(int userId)
    {
        return context.TrainingRecords.Where(record => userId == record.UserId)
            .Join(context.Exercises, record => record.ExerciseId, exercise => exercise.Id,
                (record, exercise) => new ExerciseBasicDataDTO()
                    { ExerciseName = exercise.ExerciseName, Id = exercise.Id }).Distinct().ToListAsync();
    }

    public Task<List<TrainingRecordContentDTO>> GetRecordContentByUserIdAndExerciseId(int userId, int exerciseId)
    {
        return context.TrainingRecords.Where(record => record.UserId == userId && record.ExerciseId == exerciseId)
            .Join(context.Exercises, record => record.ExerciseId, exercise => exercise.Id, (record, exercise) =>
                new TrainingRecordContentDTO()
                {
                    Id = record.Id,
                    Exercise = new ExerciseResponseDTO()
                    {
                        Id = exercise.Id,
                        ExerciseName = exercise.ExerciseName,
                    },
                    UserId = record.UserId,
                    RecordDate = record.RecordDate,
                    RepetitionsMade = record.RepetitionsMade,
                    WeightLifted = record.WeightLifted

                }).ToListAsync();
    }
}