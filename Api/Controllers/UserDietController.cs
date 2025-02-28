using Api.RequestDTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.ResponseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class UserDietController(
    IGenericRepository<UserDiet> repository,
    IMapper mapper
) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDietResponseDTO>>> GetUserDiets()
    {
        var items = await repository.ListAllAsync();
        return Ok(items.Select(item => mapper.Map<UserDietResponseDTO>(item)));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDietResponseDTO>> GetUserDietById(int id)
    {
        var item = await repository.GetByIdAsync(id);
        if (item == null) return NotFound();
        return Ok(mapper.Map<UserDietResponseDTO>(item));
    }

    [HttpPost]
    public async Task<ActionResult<bool>> PostUserDiet(CreateUserDietDTO dto)
    {
        var entity = mapper.Map<UserDiet>(dto);
        repository.AddAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<bool>> PutUserDietById(int id, CreateUserDietDTO dto)
    {
        var entity = mapper.Map<UserDiet>((dto, id));
        repository.UpdateAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteUserDietById(int id)
    {
        var entity = await repository.GetByIdAsync(id);
        if (entity == null) return NotFound();
        repository.DeleteAsync(entity);
        return Ok(await repository.SaveChangesAsync());
    }
}