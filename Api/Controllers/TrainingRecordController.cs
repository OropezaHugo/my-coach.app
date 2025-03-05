using Api.RequestDTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TrainingRecordController
(
    IGenericRepository<TrainingRecord> repository,
    ITrainingRecordRepository trainingRecordRepository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrainingRecordResponseDTO>>> GetTrainingRecords()
    {
        var trainingRecords = await repository.ListAllAsync();
        return Ok(trainingRecords.Select(trainingRecord => mapper.Map<TrainingRecordResponseDTO>(trainingRecord)));
    }
    
    [HttpGet("user/{userId}/exercises")]
    public async Task<ActionResult<IEnumerable<ExerciseBasicDataDTO>>> GetTrainingRecordExerciseBasicDataByUserId(int userId)
    {
        
        var basicExerciseData = await trainingRecordRepository.GetRecordExercisesByUserId(userId);
        return Ok(basicExerciseData);
    }

    [HttpGet("user/{userId}/exercise/{exerciseId}")]
    public async Task<ActionResult<IEnumerable<TrainingRecordContentDTO>>> GetTrainingRecordsContentByUserIdAndExerciseId(int userId, int exerciseId)
    {
        var trainingRecordsContent = await trainingRecordRepository.GetRecordContentByUserIdAndExerciseId(userId, exerciseId);
        return Ok(trainingRecordsContent);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<TrainingRecordResponseDTO>> GetTrainingRecordById(int id)
    {
        var trainingRecord = await repository.GetByIdAsync(id);
        if (trainingRecord == null) return NotFound();
        return Ok(mapper.Map<TrainingRecordResponseDTO>(trainingRecord));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> PostTrainingRecord(CreateTrainingRecordDTO trainingRecordDto)
    {
        var trainingRecord = mapper.Map<TrainingRecord>(trainingRecordDto);
        repository.AddAsync(trainingRecord);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutTrainingRecordById(int id, CreateTrainingRecordDTO trainingRecordDto)
    {
        var trainingRecord = mapper.Map<TrainingRecord>((trainingRecordDto, id));
        repository.UpdateAsync(trainingRecord);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteTrainingRecordById(int id)
    {
        var trainingRecord = await repository.GetByIdAsync(id);
        if (trainingRecord == null) return NotFound();
        repository.DeleteAsync(trainingRecord);
        return Ok(await repository.SaveChangesAsync());
    }
}