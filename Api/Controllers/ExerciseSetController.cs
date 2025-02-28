using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.ExerciseEntities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class ExerciseSetController(
    IGenericRepository<ExerciseSet> repository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExerciseSetResponseDTO>>> GetExerciseSets()
    {
        var items = await repository.ListAllAsync();
        return Ok(items.Select(item => mapper.Map<ExerciseSetResponseDTO>(item)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExerciseSetResponseDTO>> GetExerciseSetById(int id)
    {
        var item = await repository.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(mapper.Map<ExerciseSetResponseDTO>(item));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> PostExerciseSet(CreateExerciseSetDTO dto)
    {
        var entity = mapper.Map<ExerciseSet>(dto);
        repository.AddAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutExerciseSetById(int id, CreateExerciseSetDTO dto)
    {
        var entity = mapper.Map<ExerciseSet>((dto, id));
        repository.UpdateAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteExerciseSetById(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity == null) return NotFound();
        repository.DeleteAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }
}