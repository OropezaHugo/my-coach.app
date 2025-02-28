using Api.RequestDTOs;
using AutoMapper;
using Core.Entities.ExerciseEntities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;


[ApiController]
[Route("/api/[controller]")]
public class RoutineController
(
    IGenericRepository<Routine> repository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RoutineResponseDTO>>> GetRoutines()
    {
        var routines = await repository.ListAllAsync();
        return Ok(routines.Select(routine => mapper.Map<RoutineResponseDTO>(routine)));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<RoutineResponseDTO>> GetRoutineById(int id)
    {
        var routine = await repository.GetByIdAsync(id);
        if (routine == null) return NotFound();
        return Ok(mapper.Map<RoutineResponseDTO>(routine));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> PostRoutine(CreateRoutineDTO routineDto)
    {
        var routine = mapper.Map<Routine>(routineDto);
        repository.AddAsync(routine);
        return Ok(await repository.SaveChangesAsync());
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutRoutineById(int id, CreateRoutineDTO routineDto)
    {
        var routine = mapper.Map<Routine>((routineDto, id));
        repository.AddAsync(routine);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteRoutineById(int id)
    {
        var routine = await repository.GetByIdAsync(id);
        if (routine == null) return NotFound();
        repository.DeleteAsync(routine);
        return Ok(await repository.SaveChangesAsync());
    }
}
