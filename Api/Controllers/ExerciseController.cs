using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.TrainingPlanEntities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ExerciseController(
    IGenericRepository<Exercise> repository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExerciseResponseDTO>>> GetExercises()
    {
        var items = await repository.ListAllAsync();
        return Ok(items.Select(item => mapper.Map<ExerciseResponseDTO>(item)));
    }
    
    [HttpGet("basicData")]
    public async Task<ActionResult<IEnumerable<ExerciseBasicDataDTO>>> GetExercisesBasicData()
    {
        var items = await repository.ListAllAsync();
        return Ok(items.Select(item => mapper.Map<ExerciseBasicDataDTO>(item)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExerciseResponseDTO>> GetExerciseById(int id)
    {
        var item = await repository.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(mapper.Map<ExerciseResponseDTO>(item));
    }

    [HttpPost]
    public async Task<ActionResult<ExerciseResponseDTO>> PostExercise(CreateExerciseDTO dto)
    {
        var entity = mapper.Map<Exercise>(dto);
        var newExercise = repository.AddAsync(entity);
        await repository.SaveChangesAsync();
        return Ok(mapper.Map<ExerciseResponseDTO>(newExercise));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutExerciseById(int id, CreateExerciseDTO dto)
    {
        var entity = mapper.Map<Exercise>((dto, id));
        repository.UpdateAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteExerciseById(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity == null) return NotFound();
        repository.DeleteAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }
}