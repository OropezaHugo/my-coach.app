using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.ExerciseEntities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class RoutineExerciseController(
    IGenericRepository<RoutineExercise> repository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoutineExerciseResponseDTO>>> GetRoutineExercises()
    {
        var items = await repository.ListAllAsync();
        return Ok(items.Select(item => mapper.Map<RoutineExerciseResponseDTO>(item)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<RoutineExerciseResponseDTO>> GetRoutineExerciseById(int id)
    {
        var item = await repository.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(mapper.Map<RoutineExerciseResponseDTO>(item));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> PostRoutineExercise(CreateRoutineExerciseDTO dto)
    {
        var entity = mapper.Map<RoutineExercise>(dto);
        repository.AddAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }

    
    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutRoutineExerciseById(int id, CreateRoutineExerciseDTO dto)
    {
        var entity = mapper.Map<RoutineExercise>((dto, id));
        repository.UpdateAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteRoutineExerciseById(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity == null) return NotFound();
        repository.DeleteAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }
}