using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.TrainingPlanEntities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class TrainingPlanRoutineController
(
    IGenericRepository<TrainingPlanRoutines> repository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrainingPlanRoutineResponseDTO>>> GetTrainingPlanRoutines()
    {
        var trainingPlanRoutines = await repository.ListAllAsync();
        return Ok(trainingPlanRoutines.Select(trainingPlanRoutine => mapper.Map<TrainingPlanRoutineResponseDTO>(trainingPlanRoutine)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TrainingPlanRoutineResponseDTO>> GetTrainingPlanRoutineById(int id)
    {
        var trainingPlanRoutine = await repository.GetByIdAsync(id);
        if (trainingPlanRoutine == null) return NotFound();
        return Ok(mapper.Map<TrainingPlanRoutineResponseDTO>(trainingPlanRoutine));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> PostTrainingPlanRoutine(CreateTrainingPlanRoutineDTO trainingPlanRoutineDto)
    {
        var trainingPlanRoutine = mapper.Map<TrainingPlanRoutines>(trainingPlanRoutineDto);
        repository.AddAsync(trainingPlanRoutine);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutTrainingPlanRoutineById(int id, CreateTrainingPlanRoutineDTO trainingPlanRoutineDto)
    {
        var trainingPlanRoutine = mapper.Map<TrainingPlanRoutines>((trainingPlanRoutineDto, id));
        repository.UpdateAsync(trainingPlanRoutine);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteTrainingPlanRoutineById(int id)
    {
        var trainingPlanRoutine = await repository.GetByIdAsync(id);
        if (trainingPlanRoutine == null) return NotFound();
        repository.DeleteAsync(trainingPlanRoutine);
        return Ok(await repository.SaveChangesAsync());
    }
}