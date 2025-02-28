using Api.RequestDTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UserRoutineController(
    IGenericRepository<UserRoutine> repository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserRoutineResponseDTO>>> GetUserRoutines()
    {
        var items = await repository.ListAllAsync();
        return Ok(items.Select(item => mapper.Map<UserRoutineResponseDTO>(item)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserRoutineResponseDTO>> GetUserRoutineById(int id)
    {
        var item = await repository.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(mapper.Map<UserRoutineResponseDTO>(item));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> PostUserRoutine(CreateUserRoutineDTO dto)
    {
        var entity = mapper.Map<UserRoutine>(dto);
        repository.AddAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutUserRoutineById(int id, CreateUserRoutineDTO dto)
    {
        var entity = mapper.Map<UserRoutine>((dto, id));
        repository.UpdateAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteUserRoutineById(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity == null) return NotFound();
        repository.DeleteAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }
}
