using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.TrainingPlanEntities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class SetController(
    IGenericRepository<Set> repository,
    ISetRepository setRepository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SetResponseDTO>>> GetSets()
    {
        var items = await repository.ListAllAsync();
        return Ok(items.Select(item => mapper.Map<SetResponseDTO>(item)));
    }
    
    [HttpGet("exercise/{id}")]
    public async Task<ActionResult<IEnumerable<SetResponseDTO>>> GetSetsByExerciseId(int id)
    {
        var items = await setRepository.GetSetsByExerciseId(id);
        return Ok(items.Select(item => mapper.Map<SetResponseDTO>(item)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SetResponseDTO>> GetSetById(int id)
    {
        var item = await repository.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(mapper.Map<SetResponseDTO>(item));
    }

    [HttpPost]
    public async Task<ActionResult<SetResponseDTO>> PostSet(CreateSetDTO dto)
    {
        var entity = mapper.Map<Set>(dto);
        var newSet = repository.AddAsync(entity);
        await repository.SaveChangesAsync();
        return Ok(mapper.Map<SetResponseDTO>(newSet));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutSetById(int id, CreateSetDTO dto)
    {
        var entity = mapper.Map<Set>((dto, id));
        repository.UpdateAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteSetById(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity == null) return NotFound();
        repository.DeleteAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }
}
