using Core.ResponseDTOs;

namespace Core.Interfaces;

public interface ITrainingRecordRepository
{
    Task<List<ExerciseBasicDataDTO>> GetRecordExercisesByUserId(int userId);
    Task<List<TrainingRecordContentDTO>> GetRecordContentByUserIdAndExerciseId(int userId, int exerciseId);
}